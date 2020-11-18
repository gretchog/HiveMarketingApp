Solution consists of:
- DataProvider -> A datalayer which handles interaction with the database
- DataObjects -> The plain data classes which handle our data
- Services -> Actually unused in this project, but usually this is where I'd add any server-side processing
- WebApi -> Our front-end and communications layer

Used dependency injection to ensure components could be swapped out, also makes unit testing easier/feasible.

Some basic unit tests, not really going for 100% coverage at this point, just want to make sure I have something to work towards.
Would also use automation tests to cover front-end if this were a longer-term project.