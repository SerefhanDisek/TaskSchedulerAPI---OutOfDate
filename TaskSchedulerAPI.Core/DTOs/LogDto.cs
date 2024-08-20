using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSchedulerAPI.Core.DTOs
{
    public class LogDto
    {
        public DateTime Timestamp { get; set; }  // Log kaydının oluşturulduğu zaman
        public string LogLevel { get; set; }     // Log seviyesini belirtir: "Information", "Warning", "Error", vb.
        public string Message { get; set; }      // Log mesajı
        public string Exception { get; set; }    // Hata mesajı varsa Exception bilgisi
        public string UserId { get; set; }       // Log kaydını oluşturan kullanıcının ID'si (isteğe bağlı)
        public string UserName { get; set; }     // Log kaydını oluşturan kullanıcının adı (isteğe bağlı)
        public string Source { get; set; }       // Log kaynağını belirtir (örneğin, hangi sınıf/metoddan geldiği)
        public string RequestId { get; set; }    // İsteğe bağlı olarak, bu log ile ilişkili bir istek ID'si
    }

}
