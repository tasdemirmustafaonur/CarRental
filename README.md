### Back-end
Projenin backend tarafı .Net Core kullanılarak yazılmıştır. N-Tier Architecture kullanılarak Core, DataAccess, Entities, Business ve Api katmanlarına ayrılmıştır. Çok katmanlı mimari yapısıyla proje yönetimin kolaylaştırılması, ölçeklenebilirlik, esneklik, yeniden kullanılabilirlik ve güvenlik gibi problemlerin çözümlerinde basit ve yalın bir yol izlenmeye çalışılmıştır.
![entitieslayer](https://user-images.githubusercontent.com/16624085/117002898-d3c38e80-acec-11eb-8b57-0f77c41030ae.png)
### Entities Layer
Veritabanı nesneleri için oluşturulmuş **Entities Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.  
![BusinessLayer](https://user-images.githubusercontent.com/16624085/117002936-e211aa80-acec-11eb-86a8-23bd1a9219e8.png)
<br>
###  Business Layer
Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan **Business Katmanı**'nda **Abstract**,**Concrete**,**Utilities** ve **ValidationRules** olmak üzere dört adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.Utilities ve ValidationRules klasörlerinde validation işlemlerinin gerçekleştiği classlar mevcuttur.  
<br>
![dataaccesslayer](https://user-images.githubusercontent.com/16624085/117002975-f2c22080-acec-11eb-9228-83df11a74ca6.png)
###  Data Access Layer
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan **Data Access Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.  
<br>

![core](https://user-images.githubusercontent.com/77868230/107870091-c42f6900-6ea6-11eb-863e-63d30fa2128c.png)
###  Core Layer
Bir framework katmanı olan **Core Katmanı**'nda **DataAccess**, **Entities**, **Utilities** olmak üzere 3 adet klasör bulunmaktadır.DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir. 

### Kullanılan Teknolojiler

- .Net Core 3.1
- Restful API
- Result Türleri
- Interceptor
- Autofac
    - IoC Containers
    - AOP, Aspect Oriented Programming
        - Caching
        - Validation
- Fluent Validation
- Cache yönetimi
- JWT Authentication
- Repository Design Pattern
- Cross Cutting Concerns
    - Caching
    - Validation
- Extensions
    - Claim
        - Claim Principal

## Bu Projenin Bana Kattıkları

Bu projeyi yaparken aslında c# bildiğimi zannaderken hiç bilmediğimi öğrendim. Solid prensiplerini ve Katmanlı Mimariyi proje içerisinde kullandığımız için bu kavramları uygulamalı olarak daha iyi anladım. Bu proje sayesinde birçok yeni teknoloji öğrendim.
