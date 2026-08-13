# Integration.OrderService

Учебный (студенческий) сервис **заказов**. Шаблон для изучения интеграций с другими сервисами.

Локальная логика заказа (валидация, сохранение в PostgreSQL, ответ API) уже реализована.
Задание студентов — **только интеграции**.

## Архитектура

```
Клиент
   │
   │ HTTP/REST
   │ POST /api/orders
   ▼
Order Service
   │
   ├──── gRPC ──────────────► Product Service
   │                           │
   │                           └─ проверка товара/цены/остатка
   │
   ├──── RabbitMQ ──────────► Payment Service
   │                           │
   │                           └─ обработка оплаты
   │
   └──── Kafka ─────────────► Analytics Service
                               │
                               └─ аналитика событий
```

## Что уже умеет (готовая логика)

- `POST /api/orders` — создать заказ
- `GET /api/orders/{orderId}` — получить заказ
- Хранение заказов в PostgreSQL
- Авто‑миграции при старте
- Централизованная обработка ошибок и логирование запросов

## Стек / технологии

- **.NET 10 / ASP.NET Core Web API**
- **Entity Framework Core + Npgsql (PostgreSQL)**
- **Swagger (Swashbuckle)**
- **AutoMapper**
- **gRPC / RabbitMQ / Kafka** — пакеты подключены, реализации-заглушки нужно заменить

## Быстрый старт

1. Укажи строку подключения к PostgreSQL в `Integration.OrderService/appsettings.json` → `ConnectionStrings:DefaultConnection`.
2. Запусти проект:

```bash
dotnet run --project Integration.OrderService/Integration.OrderService.csproj
```

3. Открой Swagger UI:
   - `http://localhost:5002/swagger`

## Важно для студентов

В проекте специально оставлены **заглушки** (`NotImplementedException`) для интеграций:

| Интеграция | Клиент | Протокол | Куда смотреть |
|---|---|---|---|
| Product Service | `IProductClient` / `ProductClient` | **gRPC** | `Protos/product.proto`, `Services:ProductGrpc` |
| Payment Service | `IPaymentPublisher` / `PaymentPublisher` | **RabbitMQ** | секция `RabbitMQ` в `appsettings.json` |
| Analytics Service | `IAnalyticsPublisher` / `AnalyticsPublisher` | **Kafka** | секция `Kafka` в `appsettings.json` |

Оркестрация уже вызывается из `OrderService.CreateAsync()`:

1. Проверить товар/цену/остаток через `IProductClient` (gRPC)
2. Сохранить заказ в БД (уже реализовано)
3. Отправить событие оплаты через `IPaymentPublisher` (RabbitMQ)
4. Отправить событие аналитики через `IAnalyticsPublisher` (Kafka)

Пока заглушки не реализованы, `POST /api/orders` вернёт **501 Not Implemented** с подсказкой, какой протокол ещё не сделан.
`GET /api/orders/{orderId}` работает сразу — это локальная логика сервиса.
