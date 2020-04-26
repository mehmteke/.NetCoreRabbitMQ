RabbitMQ Kullanımı:
1) Kurulumlar:
   * https://www.erlang.org/downloads   Earlang dili indirmek için
   * https://www.rabbitmq.com/install-windows.html#installer  RabbitMQ indirmek
   * RabbitMQ ün önyüz ekranını kullanmak için  sırasıyla aşağıdaki adımları yapmak gerek:
      -- C:\Program Files\RabbitMQ Server\rabbitmq_server-3.8.3\sbin   bu dizinde cmd çalıştırmak lazım.
	  -- Sonrasında cmd de rabbitmq-plugins enable rabbitmq_management çalıştımamız laızm.
   * RabbitMQ önyüz ekranını http://localhost:15672/ bu linkte izleyeblirsiniz.
      --  Kullanıcı bilgilerini ise Kullancıı adı :guest Şifre: guest olarak giriş yapablirsiniz.
   * Onpromise olarak kullanmak ile birlikte cloud üzerinde de deploy edebilirsiniz. RabbitMQ localde değilde Cloud da kullanmak için.
      -- https://www.cloudamqp.com/
	  
Not: Alternatifleri (Microsof Azure Service Bus, Apache Kafka,Msmq).

Kaynak:
 https://www.udemy.com/course/aspnet-core-rabbitmq/learn/lecture/17440006#notes
 https://www.rabbitmq.com/tutorials/tutorial-one-dotnet.html