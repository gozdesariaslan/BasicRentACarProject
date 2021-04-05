using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded="Araba eklendi.";
        public static string CarInfoInvalid="Araba bilgileri geçersiz.";
        public static string CarDeleted="Araba silindi.";
        public static string CarUpdated="Araba güncellendi.";

        public static string BrandAdded="Marka eklendi.";
        public static string BrandDeleted="Marka silindi.";
        public static string BrandUpdated = "Marka güncellendi.";

        public static string ColorUpdated="Renk güncellendi.";
        public static string ColorDeleted="Renk silindi.";
        public static string ColorAdded="Renk eklendi.";

        public static string UserAdded="Kullanıcı eklendi.";
        public static string UserDeleted="Kullanıcı silindi.";
        public static string UserUpdated="Kullanıcı güncellendi.";

        public static string CustomerAdded="Müşteri eklendi.";
        public static string CustomerDeleted="Müşteri silindi.";
        public static string CustomerUpdated="Müşteri güncellendi.";

        public static string RentalFailed="Araç kiralama için uygun değil.";
        public static string RentalAdded="Araç kiralama başarılı.";
        public static string CarImagesReachedMaxNumberOfPhoto="Maksimum görsel sayısına ulaşıldı, daha fazla ekleme yapılamaz.";
        public static string AuthorizationDenied="Geçersiz kullanıcı";
        public static string UserRegistered = "Kayıt başarılı.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola hatası";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten kayıtlı";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
