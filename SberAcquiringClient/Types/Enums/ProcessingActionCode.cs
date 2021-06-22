﻿using System.ComponentModel.DataAnnotations;

namespace SberAcquiringClient.Types.Enums
{
    public enum ProcessingActionCode : int
    {
        [Display(Name =
            "Транзакция отклонена по причине того, что размер платежа превысил установленные лимиты Банком-эмитентом")]
        Code__20010 = -20010,

        [Display(Name = "Состояние начала транзакции")]
        Code__9000 = -9000,

        [Display(Name = "Блокировка по e-mai")]
        Code__2101 = -2101,

        [Display(Name =
            "Получен неверный ECI. Код выставляется в том случае, если пришедший в PaRes ECI не соответствует допустимому значению для данной МПС. Правило работает только для MasterCard (01,02) и Visa (05,06), где значения в скобках - допустимые для МПС")]
        Code__2020 = -2020,

        [Display(Name = "PARes от эмитента содержит iReq, вследствие чего платёж был отклонён")]
        Code__2019 = -2019,

        [Display(Name =
            "Directory server Visa или MasterCard либо недоступен, либо в ответ на запрос вовлечённости карты (VeReq) пришла ошибка связи. Это ошибка взаимодействия платёжного шлюза и серверов МПС по причине технических неполадок на стороне последних")]
        Code__2018 = -2018,

        [Display(Name = "Отклонено. Статус PARes-а не «Y»")]
        Code__2017 = -2017,

        [Display(Name = "Банк-эмитент не смог определить, является ли карта 3dsecure")]
        Code__2016 = -2016,

        [Display(Name = "VERes от DS содержит iReq, вследствие чего платёж был отклонён")]
        Code__2015 = -2015,

        [Display(Name = "Исчерпаны попытки оплаты")]
        Code__2013 = -2013,

        [Display(Name = "Данная операция не поддерживается")]
        Code__2012 = -2012,

        [Display(Name = "Банк-эмитент не смог провести авторизацию 3dsecure-карты")]
        Code__2011 = -2011,
        [Display(Name = "Несовпадение XID")] Code__2010 = -2010,

        [Display(Name =
            "Истёк срок, отведённый на ввод данных карты с момента регистрации платежа (таймаут по умолчанию - 20 минут; продолжительность сессии может быть указана при регистрации заказа; если у мерчанта установлена привилегия «Нестандартная продолжительность сессии», то берётся период, указанный в настройках мерчанта)")]
        Code__2007 = -2007,

        [Display(Name = "Означает, что эмитент отклонил аутентификацию (3DS авторизация не пройдена)")]
        Code__2006 = -2006,

        [Display(Name =
            "Означает, что мы не смогли проверить подпись эмитента, то есть PARes был читаемый, но подписан неверно")]
        Code__2005 = -2005,

        [Display(Name = "Блокировка по порту")]
        Code__2003 = -2003,

        [Display(Name =
            "Транзакция отклонена по причине того, что размер платежа превысил установленные лимиты. Примечание: имеется в виду либо лимиты Банка-эквайера на дневной оборот Магазина, либо лимиты Магазина на оборот по одной карте, либо лимит Магазина по одной операции")]
        Code__2002 = -2002,

        [Display(Name = "Транзакция отклонена по причине того, что IP-адрес Клиента внесён в чёрный список")]
        Code__2001 = -2001,

        [Display(Name = "Транзакция отклонена по причине того, что карта внесена в чёрный список")]
        Code__2000 = -2000,

        [Display(Name = "Оплата заказа была отклонена СБОЛ'о")]
        Code__999 = -999,

        [Display(Name = "Не было попыток оплаты")]
        Code__100 = -100,

        [Display(Name = "Платёж успешно прошёл")]
        Code_0 = 0,

        [Display(Name =
            "Для успешного завершения транзакции требуется подтверждение личности. В случае интернет-транзакции (соот-но и в нашем) невозможно, поэтому считается как declined")]
        Code_1 = 1,

        [Display(Name = "Отказ сети проводить транзакцию")]
        Code_5 = 5,

        [Display(Name = "МПС не смогла определить эмитента карты")]
        Code_15 = 15,

        [Display(Name = "Карты не существует в системах процессинга")]
        Code_53 = 53,
        [Display(Name = "DECLINED_BY_PINPRO")] Code_81 = 81,

        [Display(Name = "Ограничение по карте (Банк эмитент запретил интернет транзакции по карте)")]
        Code_100 = 100,

        [Display(Name = "Истёк срок действия карты")]
        Code_101 = 101,

        [Display(Name = "Нет связи с Банком-Эмитентом. Торговой точке необходимо связаться с банком-эмитентом")]
        Code_103 = 103,

        [Display(Name = "Попытка выполнения операции по счёту, на использование которого наложены ограничения")]
        Code_104 = 104,

        [Display(Name = "Превышено допустимое число попыток ввода ПИН. Вероятно карта временно заблокирована")]
        Code_106 = 106,

        [Display(Name = "Следует обратиться к Банку-Эмитенту")]
        Code_107 = 107,

        [Display(Name = "Неверно указан идентификатор продавца/терминала или АСС заблокирован на уровне процессинга")]
        Code_109 = 109,

        [Display(Name = "Неверно указана сумма транзакции")]
        Code_110 = 110,

        [Display(Name = "Неверный номер карты")]
        Code_111 = 111,

        [Display(Name = "Сумма транзакции превышает доступный остаток средств на выбранном счёте")]
        Code_116 = 116,

        [Display(Name = "Сервис не разрешён (отказ от эмитента)")]
        Code_118 = 118,

        [Display(Name = "Транзакция незаконна")]
        Code_119 = 119,

        [Display(Name =
            "Отказ в проведении операции - транзакция не разрешена эмитентом. Код ответа платёжной сети - 57. Причины отказа необходимо уточнять у эмитента")]
        Code_120 = 120,

        [Display(Name =
            "Предпринята попытка выполнить транзакцию на сумму, превышающую дневной лимит, заданный банком-эмитентом")]
        Code_121 = 121,

        [Display(Name =
            "Превышен лимит на число транзакций: клиент выполнил максимально разрешённое число транзакций в течение лимитного цикла и пытается провести ещё одну")]
        Code_123 = 123,

        [Display(Name =
            "Неверный номер карты. Подобная ошибка может означать ряд вещей: Попытка возврата на сумму, больше холда, попытка возврата нулевой суммы. Для AmEx - неверно указан срок действия карты")]
        Code_125 = 125,
        [Display(Name = "Карта утеряна")] Code_208 = 208,

        [Display(Name = "Превышены ограничения по карте")]
        Code_209 = 209,
        [Display(Name = "Реверсал обработан")] Code_400 = 400,

        [Display(Name = "Подозрительный реверса")]
        Code_433 = 433,

        [Display(Name = "Ответ получен после реверсал")]
        Code_434 = 434,

        [Display(Name = "Нет такого кода ответа от сет")]
        Code_435 = 435,

        [Display(Name =
            "Ограничение по карте (Владелец карты пытается выполнить транзакцию, которая для него не разрешена)")]
        Code_902 = 902,

        [Display(Name =
            "Предпринята попытка выполнить транзакцию на сумму, превышающую лимит, заданный банком-эмитентом")]
        Code_903 = 903,

        [Display(Name = "Ошибочный формат сообщения с точки зрения банка эмитента")]
        Code_904 = 904,

        [Display(Name =
            "Нет связи с Банком, выпустившим Вашу карту. Для данного номера карты не разрешена авторизация в режиме stand-in (этот режим означает, что эмитент не может связаться с платёжной сетью и поэтому транзакция возможна либо в оффлайне с последующей выгрузкой в бэк офис, либо она будет отклонена)")]
        Code_907 = 907,

        [Display(Name =
            "Невозможно провести операцию (Ошибка функционирования системы, имеющая общий характер. Фиксируется платёжной сетью или банком-эмитентом)")]
        Code_909 = 909,

        [Display(Name = "Банк-эмитент недоступен")]
        Code_910 = 910,

        [Display(Name = "Неверный формат сообщения (Неправильный формат транзакции с точки зрения сети)")]
        Code_913 = 913,

        [Display(Name = "Не найдена транзакция (когда посылается завершение или reversal или refund)")]
        Code_914 = 914,

        [Display(Name =
            "Отсутствует начало авторизации транзакции. Отклонено по фроду или ошибка 3dsec. После получения этого кода ответа дальнейшие попытки проведения платежа отклоняются")]
        Code_999 = 999,

        [Display(Name =
            "Пусто (Выставляется в момент регистрации транзакции, т.е. когда еще по транзакции не было введено данных карт)")]
        Code_1001 = 1001,
        [Display(Name = "Неверная операция")] Code_2002 = 2002,

        [Display(Name = "SSL (Не 3d-Secure/SecureCode) транзакции запрещены Магазину")]
        Code_2003 = 2003,

        [Display(Name = "Оплата через SSL без ввода CVС2 запрещена")]
        Code_2004 = 2004,

        [Display(Name = "Платёж не соответствует условиям правила проверки по 3ds")]
        Code_2005 = 2005,

        [Display(Name = "Однофазные платежи запрещены")]
        Code_2006 = 2006,

        [Display(Name = "Транзакция ещё не завершена")]
        Code_2008 = 2008,

        [Display(Name = "Сумма возврата превышает сумму оплаты")]
        Code_2009 = 2009,

        [Display(Name = "Ошибка выполнения 3DS-правила")]
        Code_2014 = 2014,

        [Display(Name = "Ошибка выполнения правила выбора терминала (правило некорректно)")]
        Code_2015 = 2015,

        [Display(Name = "Мерчант не имеет разрешения на 3-D Secure, необходимое для проведения платежа")]
        Code_2016 = 2016,
        [Display(Name = "Заказ отклонён")] Code_2022 = 2022,

        [Display(Name = "Очередь на запросов на обработку в процессинг превысила допустимый лимит")]
        Code_2023 = 2023,

        [Display(Name = "Заказ отклонён продавцом")]
        Code_4005 = 4005,

        [Display(Name = "Введены неправильные параметры карты")]
        Code_71015 = 71015,

        [Display(Name = "Таймаут в процессинге. Не удалось отправить")]
        Code_151018 = 151018,

        [Display(Name = "Таймаут в процессинге. Удалось отправить, но не получен ответ от банка")]
        Code_151019 = 151019,
        [Display(Name = "Код отказа РБС")] Code_341014 = 341014
    }
}