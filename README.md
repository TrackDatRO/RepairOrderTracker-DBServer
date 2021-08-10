## Repair Order Tracker App

This is the database API where the connections for the front-end will be handled.

----

This is going to be where I try to describe what the hell im doing.

## The idea:

A coworker was "promoted" to team leader and is having a hard time keeping track of the hundreds of repair orders (ROs) that go through the shop in a week. This makes things like keeping the teams labor balanced and time management a pain in the ass.

I want this app to be able to store 2 - 3 months worth of ROs and any that are active, allow him, and anyone, to be able to easily see what there is, where it is and how the team is doing.

Now, one would think this is something easy and should be built into what ever app is used by the dealership to manage all of this in the first place. Well one would be `wrong`. If it exists, we plebian technicians dont get access to it. Besides, after using these apps, i doubt if the managers get access to anything that usefull.

## How this is going to work:

The basics of a database access and management system is the essentials and after that basic foundation is layed, things like charting and predictive suggestions are future plans.

> First things first, the `Database`. Its a MongoDB running on [Atlas](https://www.mongodb.com/cloud/atlas) so the database host is not an issue. traffic wont be that big and if things get too busy or slow it down too much, i can upgrade the clusters.

> The database `API`. The plan is ASP .NET 5.0 running in a docker container, hosted...somewere. Not sure where or how thats going to work yet. ASP .NET is still new to me and certain stuff like [Mongoose](https://mongoosejs.com/docs/) doesnt have an equivalent (that im aware of), which means im building all the relational requirements of the database by hand.

> The `Front-End`: This is not too bad. Its [Next.js](https://nextjs.org/docs/getting-started) with TypeScript. Things like documentation arent a big deal. Info is pretty easy to come by. Probably going to use [Netlify](https://www.netlify.com/products/workflow/) for hosting. Theres not much more to say. Im not going to use [Material-UI](https://material-ui.com/) or something similar. This is a good oportunity to learn how to create modern GUIs with CSS and my own two hands.

### The Current Feature List:

- Store modify and recall data from the database
- Assign techs to a repair order, connect jobs to that repair order, and store the repair orders in a pay period.
- Track total labor hours from the completed jobs and display it in an intuitive and clear way.
- Keep a rolling history of work completed by a team.

### The Current Technologies:

* React
* Next.js
* Express
* Auth0
* Typescript
* MongoDB
* Atlas
* Docker
* ASP .NET
* C#

#### Theres no timeline. I don't know when this will be done.

----

### Running the dev environment:


- Pull the repository from github
- Make sure the debug compiler symbols are set:
> Project>Properties>Build Tab>Check "Define DEBUG Constant" and type "testEP" into the "Contitional compilation symbols" text box
- Run the app
- If it didnt authomatically open:
- [Open the app](http://localhost:33786)

### Deplyment:

When I know how to deploy this bad boi, this is where the walkthrough will be.