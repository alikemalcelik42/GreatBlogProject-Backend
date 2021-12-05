using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcud";
        public static string AccessTokenCreated = "Bağlantı jetonu oluşturuldu";

        public static string BlogAdded { get; internal set; }
        public static string BlogDeleted { get; internal set; }
        public static string CommentsListed { get; internal set; }
        public static string BlogUpdated { get; internal set; }
        public static string LileDeleted { get; internal set; }
        public static string CommentAdded { get; internal set; }
        public static string CommentUpdated { get; internal set; }
        public static string LikeAdded { get; internal set; }
        public static string LikesListed { get; internal set; }
        public static string LikeUpdated { get; internal set; }
    }
}
