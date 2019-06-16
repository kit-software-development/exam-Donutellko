# McDonats

An ordering system for fastfood restaurant McDonat's. 

The project contains Server and Client. 

## How to build and deploy

The server application can be build with
```gradle bootJar``` 
and then ran using 
```java -jar build/libs/*.jar --server.port=8080```

or just with
```gradle bootRun```

The client is somehow build in Visual Studio (tested in VS 2019). 
Url of the server is provided to client application through source code:
```
McDonatsClient/Forms/MainForm.cs:

private String Url { get; set; } = "http://muffin-ti.me:8086"; // example (accessible)
```
The url above will be active for several days, so /McDonatsClient/bin/Debug/McDonatsClient.exe can
be run right away without need to recompile.



## Client application

The client application, written using C# .NET Framework and Windows Forms, is meant to
be used by customers on terminals, installed in restaurant, to order food from menu. 
Application allows customer to order only those items that are present in restaurant storage. 
When customer ordered last item, other customers are not able to order this item.
After client formed and confirmed their order, it is sent to Server. Server returns cheque, if
order was validated and added to queue for processing, or an error message otherwise.
A cheque contains order id and a security code that is used to prove rights for the order When
receiving it, get information about it, or cancel an order (not awailable). 

## Server application

Server validates the order and reserves the items that have beed ordered by customer, and added 
it to queue of orders with status OPEN. Staff members see all open orders and are able to pick one 
for processing, or cancel it. Staff member can be processing only one order. When status is set to
anything else but OPEN, a customer is unable to cancel the order anymore. After processing the 
order, staff member enters the security code from cheque to set status of order to DONE. Then they 
become able to pick another order. 

Staff members are authorised by username and password. If staff member was retired, their account 
status becomes DISABLED, and they lose ability to log in.

## Access

The database can be accessed using URL /h2-console at the server. Login is 'user' and password is 'password'.

## Disclaimer

I wanted to complete the UI for staff members as a frontend AngularJS application, but experienced 
some very strange problems with Hibernate, and spend much time trying to deal with it. However, the
most part of business logic for all the described operations is already in the project.

And the Client application doesn't look well (both UI and code) so I recommend on checking the Server 
application sources, as I spent much time trying to make it look good :)

