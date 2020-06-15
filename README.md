# ArticleProject
Article Project

Projenin ayağa kaldırılması için Api Katmanında appsetting configurasyon dosyasının içindeki connectionstring bilgisinin verilmesi gerekmektedir.

Database = MSSQL Server
Projede ORM olarak EF kullanılmıştır.
Migration aktif hale getirilmiştir.
Proje başlangıçta verilen connectionString bilgisine DB yi Create edecektir.

--Projede Kullanılan Tasarım Desenleri
Projede Kurumsal Mimari kullanıldı.
Sunum Katmanı => Api 
İş Katmanı => Bussines layer (BL)
Veri Erişim Katmanı => Data Access Layer (DAL)
Diğer Katmanlarda kullanlan Ortak kütühaneler için Core Katmanı (Core)

--DAL
  Generic Repository Patern 

--Projede Kullanılan Kütüphaneler
JWT (Json Web token) 
Autofac (Dependency Injection)
Log4Net (Loglama)
MemoryCache => Microsoft Memory Cache

--Eklenmesi Gerekenler
Validation
Swagger 
versioning




