# PhoneBook.Hillgrove

PhoneBook.Hillgrove is a console-based phonebook app built with .NET and EF Core. It starts by creating a fresh SQLite database, then opens a menu-driven interface where you can manage contacts, categories, and a fake email action that is used as a simple demo instead of a real mail system.

## Features

- Add, update, view, and delete contacts
- Group contacts into categories and filter contacts by category
- Send a simulated email to a contact

## Tech stack

- .NET 10 / C#
- Entity Framework Core with SQLite
- Spectre.Console for the terminal UI

## Getting started

Requires the .NET 10 SDK. From the repo root:

```
dotnet run --project PhoneBook.Hillgrove
```

## How the app works

The app follows a simple flow:

1. On startup it resets and recreates the database.
2. The main menu lets you choose between contacts, categories, sending email, or quitting.
3. Inside the contacts menu, you can add, update, view, filter by category, and delete contacts.
4. Inside the categories menu, you can add, update, view, and delete categories.
5. The email option lets you pick a contact, enter a subject and message, and preview the sent email. It is intentionally fake: built to look like a real email service from the caller's side, but it doesn't actually send anything, so I didn't need to wire up real SMTP credentials or an email provider just for this project.

The database is deleted and recreated on each run so every start begins from the same known state, which made it easier to test the menus and data flow without old data getting in the way. This also matches how the tutorial video I followed handled it.

## Challenges

The project brief included a few challenge ideas:

- Create a functionality that allows users to add the contact's e-mail address and send an e-mail message from the app: done. The app stores contact emails and includes a send-email flow.
- Expand the app by creating categories of contacts (i.e. Family, Friends, Work, etc): done. Contacts can be grouped into categories and filtered by them.
- What if you want to send not only e-mails but SMS?: not implemented. The cleanest next step would be a shared notification interface, such as a common sender abstraction with `Send(...)`, backed by email and SMS implementations.
- Create a unit tests project and test your validation methods, passing several invalid and valid inputs: not done. The validators are simple guard clauses with little regression risk, and testing them felt like practice for its own sake rather than something that would change the project. I'd rather spend that time on the next project, even if it costs some testing practice.

My take on the SMS idea. Without a refactor, this would mean duplicating the whole flow (pick a contact, enter a message, confirm) for a second feature that's nearly identical to the first. If I did refactor, I would normally reach for interfaces and depend on an abstraction instead of concrete classes. A template method is another option, where a shared base class holds the flow and only the delivery step gets overridden per channel. Interfaces scale better if the two channels start differing in more than just delivery, while a template method is simpler if delivery really is the only difference.

## Thought process

I worked on the app one slice at a time, or feature by feature, revisiting the architecture along the way since it's more of an n-layered design than a strict MVC one. I also thought about using async, but it was not necessary for this app since it is only one user and one thread.

I used both `UseSeeding` and `UseSeedingAsync` because EF Core expects both to be set up together. The app only calls the sync path today, but this way the same seed logic keeps working if that ever changes to async.

## What was hard?

Figuring out each layer's responsibility took some getting used to, since the architecture looks a bit like MVC but is really n-layered. EF Core was also new to me, so seeding and relationships took extra time to click.

## What was easy?

Flow control, input handling, and the overall menu structure came together quickly.

## What have I learned?

How EF Core's newer seeding hooks (`UseSeeding`/`UseSeedingAsync`) work, compared to older approaches like `HasData`.