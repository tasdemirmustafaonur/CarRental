﻿using System.Runtime.Serialization;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarDeleted = "Araba silindi";
        public static string CarUpdated = "Araba guncellendi";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarListed = "Araba listelendi";
        public static string CarNotExist = "Araba mevcut degil";

        public static string BrandAdded = "Marka eklendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandUpdated = "Marka guncellendi";
        public static string BrandsListed = "Markalar listelendi";
        public static string BrandListed = "Marka listelendi";
        public static string BrandNotExist = "Marka mevcut degil";
        public static string BrandExist = "Marka zaten mevcut";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorDeleted = "Renk silindi";
        public static string ColorUpdated = "Renk guncellendi";
        public static string ColorsListed = "Renkler listelendi";
        public static string ColorListed = "Renk listelendi";
        public static string ColorNotExist = "Renk mevcut degil";
        public static string ColorNameExist = "Renk zaten mevcut";

        public static string UserAdded = "Kullanici eklendi";
        public static string UserDeleted = "Kullanici silindi";
        public static string UserUpdated = "Kullanici guncellendi";
        public static string UsersListed = "Kullanicilar listelendi";
        public static string UserListed = "Kullanici listelendi";
        public static string UserNotExist = "Kullanici mevcut degil";
        public static string UserEmailExist = "E-mail zaten kayitli";

        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerDeleted = "Müşteri silindi";
        public static string CustomerUpdated = "Müşteri güncellendi";
        public static string CustomersListed = "Müşteriler listelendi";
        public static string CustomerListed = "Müşteri listelendi";
        public static string CustomerNotExist = "Musteri mevcut degil";

        public static string RentalAdded = "Kiralama eklendi";
        public static string RentalDeleted = "Kiralama silindi";
        public static string RentalUpdated = "Kiralama guncellendi";
        public static string RentalsListed = "Kiralamalar listelendi";
        public static string RentalListed = "Kiralama listelendi";
        public static string RentalCarNotAvailable = "Kiralanmak istenen arac daha once kiralanmis";
        public static string RentalNotExist = "Kiralama mevcut degil";
        public static string ReservationBetweenSelectedDatesExist = "Secilen tarihler arasinda zaten bir rezervasyon mevcut";
        public static string CarCanBeRentedBetweenSelectedDates = "Araba, secilen tarihler arasinda kiralanabilir";
        public static string CarAlreadyRentedByTheReservationDate = "Araba, rezervasyon tarihine kadar kiralanmis";
        public static string RentDateMustBeGreaterThanReturnDate = "Kiralama tarihi, dönüs tarihinden buyuk olmalidir";
        public static string RentalSuccessful = "Kiralama basarili";

        public static string CarImagesListed = "Arabanın resimleri listelendi";
        public static string CarsImagesListed = "Tüm araba resimleri listelendi";
        public static string CarImageListed = "Araba resmi listelendi";
        public static string CarImageAdded = "Araba resmi eklendi";
        public static string CarImageDeleted = "Araba resmi silindi";
        public static string CarImageUpdated = "Araba resmi güncellendi";
        public static string ErrorUpdatingImage = "Resim güncellenirken hata oluştu";
        public static string ErrorDeletingImage = "Resim silinirken hata oluştu";
        public static string CarImageLimitExceeded = "Bu araca daha fazla resim eklenemez";
        public static string CarImageIdNotExist = "Araba resmi mevcut degil";
        public static string UserAlreadyCustomer = "Kullanici zaten bir musteridir";
        public static string GetDefaultImage = "Arabanin bir resmi olmadigi icin varsayilan resim getirildi";
        public static string NoPictureOfTheCar = "Arabanin hic resmi yok";

        public static string AuthorizationDenied = "Bu islemi yapmak icin yetkiniz yok";
        public static string UserRegistered = "Kullanici kayit basarili";
        public static string UserNotFound = "Kullanici bulunamadi";
        public static string PasswordError = "Sifre hatali";
        public static string SuccessfulLogin = "Giris basarili";
        public static string UserAlreadyExists = "Kullanici zaten sisteme kayitli";
        public static string AccessTokenCreated = "Token basariyla olusturuldu";

        public static string DeliveryStatusMustBeNull = "Teslim durumu null olmalidir";
        public static string DeliveryStatusMustBeFalse = "Teslim durumu false olmalidir";
        public static string DeliveryStatusCanNotBeNull = "Teslim durumu null olamaz";

        public static string CreditCardNotValid = "Kredi karti bilgileri dogrulanamadi";
        public static string PaymentSuccessful = "Odeme basariyla tamamlandi";
        public static string InsufficientCardBalance = "Kart bakiyesi yetersiz";

        public static string StringMustConsistOfNumbersOnly = "String, sadece sayilardan olusmalidir";
        public static string LeastOneCustomerIdDoesNotMatch = "Ödemedeki müsteri id'si ile en az bir kiralamadaki müsterinin id'si uyusmuyor";
        public static string TotalAmountNotMatch = "Kiralamalardaki toplam tutar ile ödenecek toplam tutar uyusmuyor";
    }
}
