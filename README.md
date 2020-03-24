# SPA-Demo-CRUD
demo app (crud): react // c# .net core && web-api // authorization + registration + [reCaptcha v2](https://github.com/badhitman/reCaptcha)

решение не имеет практического применения. обычная демка для частных нужд.

Окно неавторизованного пользователя:
![домашняя страница незарегистрированного пользователя](./screenshots/home-page-guest.jpg)

Для **"Debug"** сборок при включении в конфигурационном файле "загрузки" демо-данных (требуются выполнение обоих условий) в интерфейсе «аутентификации» выводится вспомогательная функциональная область для упрощённого входа в различные учётные записи. У каждой демо-учётки права соответствуют её имени (если роль не была переназначена вручную).
Для быстрого заполнения формы авторизации учётными данными из данной «подсказки», достаточно совершить двойной клик по интересующей учётной записи.
![страница входа/регистрации пользователя 1](./screenshots/log-in.jpg)

Системное/серверное сообщение контроля валидации моделей для отправляемых форм входа/регистрации.
![страница входа/регистрации пользователя 2](./screenshots/log-in-2.jpg)

Кроме валидации модели сервер сообщает о статусе отправляемого запроса. В случае ошибки будет выведено соответствующее уведомление.
![страница входа/регистрации пользователя 3](./screenshots/log-in-3.jpg)

Поддержка [reCaptcha v2](https://github.com/badhitman/reCaptcha). Для включения/отключения данной системы контроля в настройках нужно добавить/удалить (равно, как и закомментировать/раскомментировать) ваши ключи от reCaptcha.
![страница входа/регистрации пользователя (off-registration)](./screenshots/log-in-off-registration.jpg)

В зависимости от назначенной роли/политики пользователю выводиться соответствующее меню. Состав меню для каждой роли/политики формируется на стороне сервера. Политики выстроены в вертикальную иерархию и наследуются от младшего к старшему.
Другими словами: на контроллеры и их методы накладываются не конкретные роли, а минимальный требуемый уровень.
В таком случае доступ к web-api имеют все, кто чей уровень доступ равен требуемому уровню или старше.

Меню простого авторизованного пользователя
![домашняя страница пользователя](./screenshots/menu-user.jpg)

Меню администратора
![домашняя страница администратора](./screenshots/menu-admin.jpg)

Меню для **root**.
![страница выхода из сессии пользователя](./screenshots/log-out.jpg)

Контроль доступа web-api. Если клиент попытается получить доступ к web-api, прав на которое ему не хватает, то он будет перенаправлен на страницу ошибки.
Контроль доступа организован на сервере средствами **asp.net core**, а клиент отображает «заглушку» для подобной ошибки.
![контроль доступа](./screenshots/access-denied.jpg)

Список отделов/департаментов
![список доступных департаментов](./screenshots/departments-list.jpg)

Карточка департамента с пользователями. Если у департамента есть назначенные пользователи, то они будут отображены снизу
![карточка департамента 1](./screenshots/departments-card.jpg)

Пример департамента, за которым не закреплён ни один пользователь
![карточка департамента 2](./screenshots/departments-card-empty.jpg)

Удаление департамента каскадно удалит и всех прикреплённых пользователей.
![карточка департамента 3](./screenshots/departments-delete.jpg)

Список пользователей. Роли/права выделены слева от имени
![список пользователей](./screenshots/user-list.jpg)

![карточка пользователя 1](./screenshots/user-card.jpg)

![карточка пользователя 2](./screenshots/user-delete.jpg)

Пример содержания конфигурационного файла
![конфигурационный файл приложения](./screenshots/appsettings.json.jpg)
