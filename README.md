

[![NuGet](https://img.shields.io/nuget/v/DaData.ApiClient.svg?style=flat-square)](https://www.nuget.org/packages/DaData.ApiClient/)
[![Build status](https://ci.appveyor.com/api/projects/status/e35qeajuv58oylli?svg=true)](https://ci.appveyor.com/project/Xambey/dadataapiclient)

**На данный момент рекомендуется обновлять версии пакета по чаще!**

## Описание
Этот проект представляет из себя .Net реализацию клиента для работы с сервисом [DaData.ru](https://dadata.ru/)  
С ним вы сможете очень быстро начать работать с API DaData, без лишних затрат времени.
Есть полная поддержка .Net Core и .Net Standart 1.3+ 

##### На данный момент полностью реализованы все методы для работы с API:
- [Подсказки](https://dadata.ru/api/suggest/)
- [Стандартизация](https://dadata.ru/api/clean/)
- [Дополнительные методы](https://dadata.ru/api/)

## Планы 
- Добавить возможность автоматических уведомлений о превышении минимального, установленного вами лимита баланса
- Добавить возможность включать автоматический контроль за ограничениями на количество сообщений в секунду (очереди сообщений с балансировщиком), с поддержкой асинхронности

## Как использовать
**Сначала требуется так или иначе создать клиент:**
```C#
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

**Примечание**

  ***Стоит заметить, что в проекте присутствуют интерфейсы для использования (и реализации) клиента(ов) со следующими наборами методов:***
  - Подсказок
  - Стандартизации
  - Дополнительными
  
  Которые удобно использовать например для DI.
  Также клиент умеет выбрасывать исключения (включая ответы об ошибках от API из документации)
  
## Для советов, критики и предложений (или просто передачи спасибо):

  Писать на xambey@yandex.ru или в телеграм @xambey.








