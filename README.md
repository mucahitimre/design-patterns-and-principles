# Design patterns and principles

 ## UnitOfWork 
  - Bir takım işleri uygularken kontrol/performans sağlayabilmek için UnitOfWork desenini kullanırız, bu desen tüm işlerin bir seferde yapılması/yansıtılması görevini üstlenir database trancsaction yapısı en bilinen ve yaygın örneğidir, database işlemlerini anlık uygulamak yerine o session'da ki(using vs.) işlemler toplanır ve session biterken yada uygulanmasını istediğimiz anda gerçekleştirilir.
## SingleResponsibility (SRP)
  - İşi yapan method class yada modulün tek bir sorumluluğu olması demektir, eğer o sorumluluk harici bir değişiklik yapılması gerekiyor ise Single responsibility prensibini doğru uygulayamamışız demektir, doğru uygulanmış olması her bir sorumluluk için onu gerçekleştiren bir method class yada module olması demektir.
## OpenClose (OCP)
  - Bir uygulamaya yeni bir özellik eklerken mimari, tasarımsal yada temelden bir değişikliğe gereksinim duymaması o uygulamanın gelimeye açık ama değişime kapalı olduğunu yani uygulama tasarlanırken değişiklik yapmaya gerek duymadan nasıl geliştirme yapılacağının düşünüldüğü anlamına gelir.
## LiskovsSubtitution (LSP)
  - Bir class yada interface'i implement eden nesne'nin o class yada interface'de ki tüm özellikleri gerçekleştirmesi yani özelliği taşıyor olması gerektiğidir, burada yerine geçen nesne'nin bazı özelliklerini gerçekleştirememesi yanlış soyutlama yapıldığı anlamına gelebilir.
## InterfaceSegregation (ISP)
  - Interfaceleri tasarlarken iş kapsamını belirleyip işlerin farklılaştığı noktalarda interfacelerin ayrılması gerekir, işler ayrıştıkça yeniden kullanılabilirlik ve anlaşılabilirlik artacaktır, kavramları birbirinden ayırmak ve sorumlulukları dağıtmak gerekir.
## DependencyInversion (DIP)
  - Üst seviye işler yapan class'ın alt seviye iş yapan classlara doğrudan bağımlılığını tersine çevirmek için alt seviye işler yapan class'ları soyutlayarak (bkz:interface) üst seviye işler yapan classların alt seviyeye bağımlılığını tersine çevirmiş oluruz, bu da bize alt seviyede ki bir değişiklik üst seviyeyi etkilememiş olur. 
