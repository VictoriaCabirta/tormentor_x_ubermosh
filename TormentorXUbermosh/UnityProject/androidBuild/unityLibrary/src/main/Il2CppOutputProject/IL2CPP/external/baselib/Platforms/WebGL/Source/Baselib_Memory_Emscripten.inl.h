#pragma once

#include "Include/Baselib.h"
#include "Include/C/Baselib_Memory.h"

namespace Emscripten
{
    BASELIB_INLINE_IMPL Baselib_Memory_PageAllocation Baselib_Memory_AllocatePages(uint64_t pageSize, uint64_t pageCount, uint64_t alignmentInMultipleOfPageSize, Baselib_Memory_PageState pageState, Baselib_ErrorState* errorState)
    {
        if (pageState != Baselib_Memory_PageState_ReadWrite)
            errorState |= RaiseError(Baselib_ErrorCode_UnsupportedPageState);
        return PosixApi::Baselib_Memory_AllocatePages(pageSize, pageCount, alignmentInMultipleOfPageSize, pageState, errorState);
    }

    BASELIB_INLINE_IMPL void Baselib_Memory_SetPageState(void* addressOfFirstPage, uint64_t pageSize, uint64_t pageCount, Baselib_Memory_PageState pageState, Baselib_ErrorState* errorState)
    {
        if (pageState != Baselib_Memory_PageState_ReadWrite)
            errorState |= RaiseError(Baselib_ErrorCode_UnsupportedPageState);
    }
}
