

[![NuGet](https://img.shields.io/nuget/v/DaData.ApiClient.svg?style=flat-square)](https://www.nuget.org/packages/DaData.ApiClient/)
[![Build status](https://ci.appveyor.com/api/projects/status/e35qeajuv58oylli?svg=true)](https://ci.appveyor.com/project/Xambey/dadataapiclient)
[![AppVeyor tests](https://img.shields.io/appveyor/tests/Xambey/dadataapiclient.svg?style=flat-square)](https://ci.appveyor.com/project/Xambey/dadataapiclient)
[![NuGet](https://img.shields.io/nuget/dt/DaData.ApiClient.svg?style=flat-square)](https://www.nuget.org/packages/DaData.ApiClient)

## Описание
Этот проект представляет из себя .Net реализацию клиента для работы с сервисом [DaData.ru](https://dadata.ru/)  
С ним вы сможете очень быстро начать работать с API DaData, без лишних затрат времени.
Есть полная поддержка .Net Core и .Net Standart 1.3+ 

##### На данный момент полностью реализованы все методы для работы с API:
- [Подсказки](https://dadata.ru/api/suggest/)
- [Стандартизация](https://dadata.ru/api/clean/)
- [Дополнительные методы](https://dadata.ru/api/)

## RoadMap
- Добавить возможность автоматических уведомлений о превышении минимального, установленного вами лимита баланса
- Добавить возможность включать автоматический контроль за ограничениями на количество сообщений в секунду (очереди сообщений с балансировщиком), с минимальными задержками на отправку сообщений

## Установка

#### 1) Подключить клиент к проекту через [Nuget](https://www.nuget.org/packages/DaData.ApiClient/1.1.7) (Gui менеджер или CLI). Подробнее [тут](https://docs.microsoft.com/en-us/nuget/tools/package-manager-ui).
*ps:*   
```
   Install-Package DaData.ApiClient
```
**Примечание:**

   Пакет требует следующие зависимости:
   -Newtonsoft.Json (nuget)
   
#### 2) Получить API ключи (токены) на [сайте](https://dadata.ru/profile/#info) сервиса

## Использование:

```C#
//token - это Token из личного кабинета
//secret - это Secret из личного кабинета. Он нужен для некоторых методов

var client = new ApiClient(token, secret);

//Или

var client = new ApiClient(new ApiClientOptions()
{
    LimitQueries = Your Limit,
    Secret = Your Secret,
    Token = Your Token
});

//Пример вызова метода стандартизации адреса
var response = await client.StandartizationQueryAddress(new[]
{
    "address1",
    "address2"
}); 

//Или 

var response = await client.StandartizationQueryAddress(new AddressRequest()
{
    Queries = new List<string>()
    {
        "address1",
        "address2"
    }
});


//вернет модель 

//Аналогично происходят обращения и к другим методам API
```

**Дополнительно:**

  ***Стоит заметить, что в проекте присутствуют интерфейсы для использования (и реализации) клиента(ов) со следующими наборами методов:***
  - Подсказок
  - Стандартизации
  - Дополнительными
  
  Которые удобно использовать например для DI.
  Есть поддержка исключений, соответствующих кодам ошибок из документации
  
## Для связи:

  Писать на xambey@yandex.ru или в телеграм @xambey.








