# ReCapProject
### Araba Kiralama Sistemi Projesi (Yazılım Geliştirici Yetiştirme Kampı)

1.Katmanlar oluşturuldu. (Entities, DataAcces, Business, ConsoleUI) <br/>
2.Bir car nesnesi oluşturuldu. Propertyleri eklendi.<br/>
3.InMemory formatta Add, Update, Delete, GetAll, GetById operasyonları yazıldı.<br/>

**GÜNCELLEMELER**<br/>
1.Brand, Color nesneleri ve propertyleri oluşturuldu. <br/>
2.SqlServer tarafında RecapProjectDb veritabanı oluşturuldu ve Cars, Brands, Colors tabloları eklendi.<br/>
3.Sisteme generic IEntityRepository alt yapısı eklendi. <br/>
4.Car, Brand ve Color nesneleri için Entity Framework altyapısını yazıldı.<br/>
5.Sisteme yeni araba eklendiğinde araba adının minimun 2 karakter ve günlük fiyatının 0'dan büyük olması koşulları eklendi.<br/>
6.Core katmanı oluşturuldu ve evrensel kodlar içine eklendi.IEntity, IEntityRepository, EfEntityRepositoryBase <br/>
7.Arabaları CarName, BrandName, ColorName, DailyPrice olacak şekilde listelemek için join operasyonu yazıldı. Bunun için Entities katmanına CarDetailDto eklendi ve Core katmanında interface IDto oluşturuldu.<br/>
8.Core katmanında results yapılandırması yapıldı ve business katmanı buna göre refactor edildi.<br/>
9.Users, Customers, Rentals tabloları oluşturuldu. Bu entityler oluşturuldu.Bu entiylerin CRUD operasyonları yazıldı.<br/>
10.Arabanın kiralanması için teslim edilmiş olması gerektiği koşulu eklendi.<br/>
11.WebAPI katmanı oluşturuldu.
