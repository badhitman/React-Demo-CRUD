﻿////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////

namespace SPADemoCRUD.Models
{
    /// <summary>
    /// Уведомление пользователя
    /// </summary>
    public class NotificationModel : BirthdayEntityModel
    {
        /// <summary>
        /// Статус доставки уведомления (в контексте получателя)
        /// </summary>
        public DeliveryNotificationStatusesEnum DeliveryStatus { get; set; }

        /// <summary>
        /// Диалог, в рамках которого пришло уведомление
        /// </summary>
        public int ConversationId { get; set; }
        public СonversationModel Conversation { get; set; }

        public int RecipientId { get; set; }
        public UserModel Recipient { get; set; }
    }
}
