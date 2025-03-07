# Calculator-Test

Простое приложение-калькулятор на Unity

https://github.com/user-attachments/assets/5f7b7c19-4398-42af-9898-410ea3a9e330

## Описание

Это проект простого калькулятора, разработанного с использованием игрового движка Unity и написанного на языке C#. Приложение следует шаблону проектирования Model-View-Presenter (MVP), что делает его модульным и легким в сопровождении. Оно поддерживает базовые арифметические операции, такие как сложение. Приложение проверяет ввод, корректно обрабатывает ошибки и сохраняет историю вычислений.

## Особенности

- **Модульная архитектура**: Приложение разбито на модули для повторного использования.
- **Арифметические операции**: Поддерживает сложение. Легко добавить новые команды благодаря атрибутам.
- **Валидация**: Проверяет корректность ввода перед выполнением вычислений.
- **Управление историей**: Ведет учет истории вычислений, поддерживает отмену и повтор действий.

## Структура проекта

### Интерфейсы

- **ICommand**
  - Базовый интерфейс для всех команд.
- **IResultCommand<out TResult>**
  - Интерфейс для команд, которые возвращают результат.
- **ICalculateCommand**
  - Интерфейс для арифметических команд, поддерживающий выполнение операций.

### Команды

- **AddCommand**
  - Команда сложения.

### Валидация

- **ValidationResult**
  - Класс результата валидации.
- **CalculatorValidator**
  - Класс для проверки корректности ввода.

### Форматирование истории

- **HistoryFormatter**
  - Класс для форматирования записей истории.

### Фабрика команд

- **CommandFactory**
  - Фабрика для создания команд.

### Сохранение

- **ISaveComponent**
  - Интерфейс для сохранения и загрузки состояния.
- **FileSaveComponent**
  - Реализация ISaveComponent, сохраняющая состояние в файл в формате JSON.

### Модель

- **CalculatorModel**
  - Модель данных калькулятора.

### Презентер

- **CalculatorPresenter**
  - Презентер, управляющий взаимодействием между моделью и представлением.

## Добавление новых команд

Чтобы добавить новую команду, просто создайте класс команды и пометьте его атрибутом `CalculatorCommand`. 
