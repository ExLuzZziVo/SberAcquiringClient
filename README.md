# [УСТАРЕЛО в связи с переходом Сбербанка на ЮKassa] SberAcquiringClient
Библиотека для работы с API интернет-эквайринга банка Сбербанк. Используется интерфейс REST.


Создана по официальной документации со следующих источников: [1](https://securepayments.sberbank.ru/wiki/doku.php/integration:api:start#%D0%B8%D0%BD%D1%82%D0%B5%D1%80%D1%84%D0%B5%D0%B9%D1%81_rest), [2](https://developer.sberbank.ru/doc/v1/acquiring/rest-requests-about).


**Использовать только на свой страх и риск.** Тестировалась только одностадийная оплата и запрос статуса заказа. Остальное должно работать, но это не точно;)


Пример использования:


1. Для начала необходимо создать класс с настройками подключения к платежному шлюзу банка, унаследовав его от интерфейса **SberAcquiringClient.Types.Interfaces.ISberAcquiringApiSettings**, например:

```csharp
public class SberApiSettings: ISberAcquiringApiSettings
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string Token { get; set; }

    public string ApiHost { get; set; }
}
```

2. После этого, задав значения свойств этих настроек(**ApiHost** - обязательно. Также нужно задать либо **Token**, либо **UserName и Password**), можно запустить нужную операцию следующим образом:

```csharp
var apiSettings = new SberApiSettings();
// Если используете HttpClient через внедрение зависимостей
var result = await new <Операция>.ExecuteAsync(_httpClient, apiSettings);
// Если нет
var result = await new <Операция>.ExecuteAsync(apiSettings);
```

Все доступные операции находятся в пространстве имен **SberAcquiringClient.Types.Operations**


Зависимости CoreLib вы можете найти [тут](https://github.com/ExLuzZziVo/CoreLib).
