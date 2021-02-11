#pragma once

#include "Include/C/Baselib_Memory.h"
#include "Include/C/Baselib_Timer.h"
#include "Source/Baselib_Utilities.h"

#include "Source/Posix/Baselib_SystemSemaphore_PosixApi.inl.h"

#include <algorithm>

namespace Emscripten_WithPThreads
{
    using PosixApi::Baselib_SystemSemaphore_Create;
    using PosixApi::Baselib_SystemSemaphore_Acquire;
    using PosixApi::Baselib_SystemSemaphore_TryAcquire;
    using PosixApi::Baselib_SystemSemaphore_TryTimedAcquire;
    using PosixApi::Baselib_SystemSemaphore_Release;
    using PosixApi::Baselib_SystemSemaphore_Free;
}

#include "Include/C/Baselib_SystemSemaphore.h"
