# SberAcquiringClient
Библиотека для работы с API интернет-эквайринга банка Сбербанк. Используется интерфейс REST.
<br/>
<br/>
Создана по официальной документации со следующих источников: <a href="https://securepayments.sberbank.ru/wiki/doku.php/integration:api:start#%D0%B8%D0%BD%D1%82%D0%B5%D1%80%D1%84%D0%B5%D0%B9%D1%81_rest" rel="nofollow">1</a>, <a href="https://developer.sberbank.ru/doc/v1/acquiring/rest-requests-about" rel="nofollow">2</a>.
<br/>
<br/>
<b>Использовать только на свой страх и риск.</b> Тестировалась только одностадийная оплата и запрос статуса заказа. Остальное должно работать, но это не точно;)
<br/>
<br/>
Пример использования:
<br/>

1. Для начала необходимо создать класс с настройками подключения к платежному шлюзу банка, унаследовав его от интерфейса <b>SberAcquiringClient.Types.Interfaces.ISberAcquiringApiSettings</b>, например:

```csharp
public class SberApiSettings: ISberAcquiringApiSettings
{
    public string UserName { get; set; }

    public string Password { get; set; }

    public string Token { get; set; }

    public string ApiHost { get; set; }
}
```

2. После этого, задав значения свойств этих настроек(<b>ApiHost</b> - обязательно. Также нужно задать либо <b>Token</b>, либо <b>UserName и Password</b>), можно запустить нужную операцию следующим образом:

```csharp
var apiSettings = new SberApiSettings();
// Если используете HttpClient через внедрение зависимостей
var result = await new <Операция>.ExecuteAsync(_httpClient, apiSettings);
// Если нет
var result = await new <Операция>.ExecuteAsync(apiSettings);
```

Все доступные операции находятся в пространстве имен <b>SberAcquiringClient.Types.Operations</b>
<br/>
<br/>
Зависимости CoreLib вы можете найти <a href="https://github.com/ExLuzZziVo/CoreLib" rel="nofollow">тут</a>.
