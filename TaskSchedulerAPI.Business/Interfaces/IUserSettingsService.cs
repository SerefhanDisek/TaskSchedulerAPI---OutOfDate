﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface IUserSettingsService
    {
        Task<OperationResult> UpdateUserSettingsAsync(string username, UpdateUserSettingsDto updateUserSettingsDto);
    }
}
