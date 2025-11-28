## Kurulum
Kurulum öncesi bilgisayarınızda dotnet ve dotnet ef araçları olması gerekiyor.
Aşağıdaki yöntemlerden birini kullanabilirsiniz.

1. ECommerce.WebApi içerisinde bulunan appsettings.json dosyasını kendi connection string ile değiştirin.Veritabanı olarak mysql kullanıyorum. mysql bilgisayarınıza kurmak istemezseniz docker ile ayağa kaldırabilirsiniz.

2. ECommerce.DataAccess içerisinde terminal veya cmd açın ve aşağıdaki komutu girin.Bu komut veritabanını
```code
dotnet ef migrations add init
dotnet ef database update
```

Veya
Windows için setup.bat Linux için setup.bash dosyalarını kullanarak kurulum aşamasını geçebilirsiniz.


## Çalıştırma
Aşağıdaki yöntemlerden birini kullanabilirsiniz.

1. ECommerce.WebApi içerisinde terminal veya cmd açın.
2. dotnet run komutu ile uygulamayı ayağa kaldırın.
3. http://localhost:5269/swagger/index.html adresinden uygulamayı kullanabilirsiniz.

Veya

Windows için run.bat Linux için run.bash dosyalarını kullanarak uygulamayı ayağa kaldırabilirsiniz.
