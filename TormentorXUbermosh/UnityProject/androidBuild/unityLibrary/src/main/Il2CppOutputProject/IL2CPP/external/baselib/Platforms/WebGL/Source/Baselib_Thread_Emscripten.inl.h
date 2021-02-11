#pragma once

#include "Include/C/Baselib_ErrorState.h"
#include "Include/C/Baselib_Thread.h"
#include "Source/Posix/Baselib_Thread_PosixApi.inl.h"

#include <emscripten/threading.h>

namespace Emscripten_WithPThreads
{
    static inline void SetNameForCurrentThread(const char* name)
    {
        // String is internally truncated to 32 chars (+ nullterminator).
        emscripten_set_thread_name(pthread_self(), name);
    }

    constexpr auto Baselib_Thread_Create = PosixApi::Baselib_Thread_Create<SetNameForCurrentThread>;
    using PosixApi::Baselib_Thread_Join;

    // As of writing, _sched_yield compiles out to a no-op in Emscripten (asserted by looking at compiled output).
    //
    // Internally sleeping is implemented as busy loop that sleeps in 1ms or 100ms slices using futex_wait. See nanosleep implementation:
    // https://github.com/emscripten-core/emscripten/blob/4a0e93f/system/lib/pthread/library_pthread.c#L152
    // So we experimented with doing small sleeps via futex_wait, but in tests that expect to do context switches via yield, this was drastically slower.
    //
    // Instead we give the thread the opportunity to process queued work and do a sched_yield in case future versions of emscripten can make use of that.
    // This is done with emscripten_current_thread_process_queued_calls, but since Unity runs on an older sdk version, we can only use
    // emscripten_main_thread_process_queued_calls right now.
    BASELIB_INLINE_IMPL void Baselib_Thread_YieldExecution()
    {
        if (emscripten_is_main_browser_thread())
            emscripten_main_thread_process_queued_calls();
        sched_yield();
    }

    using PosixApi::Baselib_Thread_GetCurrentThreadId;
    BASELIB_INLINE_IMPL bool Baselib_Thread_SupportsThreads() { return emscripten_has_threading_support() != 0; }
}
