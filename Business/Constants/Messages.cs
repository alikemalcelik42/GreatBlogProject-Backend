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
        
        public static string BlogDeleted = "Blog silindi";
        public static string BlogAdded = "Blog eklendi";
        public static string BlogsListed = "Bloglar listelendi";
        public static string BlogUpdated = "Blog güncellendi";
        public static string LikeCountListed = "Beğeni sayısı listelendi";
        public static string DislikeCountListed = "Beğenmeme sayısı listelendi";

        public static string CommentDeleted = "Yorum silindi";
        public static string CommentAdded = "Yorum eklendi";
        public static string CommentsListed = "Yorumlar listelendi";
        public static string CommentUpdated = "Yorum güncellendi";

        public static string LikeDeleted = "Beğeni silindi";
        public static string LikeAdded = "Beğeni eklendi";
        public static string LikesListed = "Beğeniler listelendi";
        public static string LikeUpdated = "Beğeni güncellendi";
        public static string SameUserCannotLikeSameBlogMoreThanOnce = "Aynı blogu aynı kullanıcı birden fazla beğenemez";

        public static string DislikeDeleted = "Beğenmeme silindi";
        public static string DislikeAdded = "Beğenmeme eklendi";
        public static string DislikesListed = "Beğenmemeler listelendi";
        public static string DislikeUpdated = "Beğenmeme güncellendi";
        public static string SameUserCannotDislikeSameBlogMoreThanOnce = "Aynı blogu aynı kullanıcı birden fazla beğenememez";
    }
}
