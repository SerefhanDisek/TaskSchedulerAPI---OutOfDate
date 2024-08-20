using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSchedulerAPI.Core.DTOs;

namespace TaskSchedulerAPI.Business.Interfaces
{
    public interface INotificationService
    {
        Task<OperationResult> SendNotificationAsync(SendNotificationDto sendNotificationDto);
        Task<IEnumerable<NotificationDto>> GetUserNotificationsAsync(string userId);
        Task<OperationResult> MarkAsReadAsync(string notificationId);
    }
}
