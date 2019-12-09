use AdventureWorks2017;
go

-- select 
select *
from Person.Person;

select firstname, lastname, middlename
from Person.Person;

-- Select every entry from Person.Person who's name is Robert
select firstname, lastname, middlename
from Person.Person
where firstname = 'robert';

-- select every entry from Person.Person who's name is Robert or John
select firstname, lastname, middlename
from Person.Person
where firstname = 'robert' or firstname = 'john';

-- Select every entry from Person.Person who's name is not Robert or John, <> means not equal
select firstname, lastname, middlename
from Person.Person
where firstname <> 'robert' and firstname <> 'john';

-- % means zero or many, so it will select any with robert at the beginning, middle, or end of the name
-- _ means exactly 1, so query would give roberts or roberto, but not robertson
-- [] will look for any of the contained characters, so query would give any name that started with ra, re, ri, ro, ru
select firstname, lastname, middlename
from Person.Person
where firstname like '%robert%' or firstname like 'robert_' or firstname like 'r[aeiou]%';

-- this query will group entries with the same first and last names in one group
select firstname, lastname
from Person.Person
where firstname = 'robert' or firstname = 'john'
group by firstname, lastname;

-- count(*) adds a new column that counts the number of entries in each grouping from above, as is used to add a title to the column, [] lets you have spaces, double quotes do this in other sql versions
select count(*) as [amount of], firstname, lastname
from Person.Person
where firstname = 'robert' or firstname = 'john'
group by firstname, lastname
having count(*) > 1;

-- this will sort the data by last name alphabetically and then the second sort by firstname will be done, but will not change the first sort
select count(*) as [amount of], firstname, lastname
from Person.Person
where firstname = 'robert' or firstname = 'john'
group by firstname, lastname
having count(*) > 1
order by lastname asc, firstname desc;

--mode of execution
/*
FROM
WHERE
GROUP BY
HAVING BY
SELECT
ORDER BY
*/

-- insert
select * 
from Person.Address
where AddressLine1 = 'UT';

insert into Person.Address(AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid)
values ('UT', NULL, 'Arlington', 79, '76010', 0xE6100000010CAE8BFC28BCE4474067A89189898A5EC0, '9aadcb0d-36cf-483f-84d8-585c2d4ec6e4');

insert into Person.Address
select AddressLine1, AddressLine2, City, StateProvinceID, PostalCode, SpatialLocation, rowguid
from AdventureWorks2017.Person.Address
where AddressLine1 = 'UT'

bulk insert Person.Address from 'data.csv' with (rowterminator = '\n', fieldterminator = ',');

--update (to prevent ruining data, write updates as select first so you know exactly what you're changing)
update Person.Person
set firstname = 'john'
where FirstName = 'robert';

update pp
set firstname = 'robert'
from Person.Person as pp
where pp.LastName = 'jones';

-- delete
delete 
from Person.Person
where MiddleName is null and FirstName = '';

-- join, always start with the table that has the least amount of information, since this will be the least number of records you need
select pp.firstname, pp.lastname, pa.AddressLine1, pa.city, pa.PostalCode
from Person.Person as pp
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityId = pp.BusinessEntityId
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
where pp.firstname = 'jimmy';

--use joins to find all the products any jimmy has bought
select pp.firstname, pp.lastname, prpr.Name, ssoh.OrderDate
from Person.Person as pp
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityId = pp.BusinessEntityId
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join Sales.salesOrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderID
inner join Production.product as prpr on prpr.ProductID = ssod.ProductID
where pp.firstname = 'jimmy' and month(ssoh.OrderDate) = 7 AND prpr.Name like '%tire%';

--the above, you have to load a lot of data to find 3 things, so we use CTE (Common Table Expressions to trim down the amount of entries we have to load)
--here is an example with sub-queries
select pp.firstname, pp.lastname, prpr.Name, ssoh.OrderDate
from Person.Person as pp
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityId = pp.BusinessEntityId
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join 
(
    select salesorderid, customerid, OrderDate
    from sales.SalesOrderHeader
    where datepart(month, OrderDate)=7    
) as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderID
inner join
(
    select productid, name
    from Production.Product
    where name like '%tire%'
) as prpr on prpr.ProductID = ssod.ProductID
where pp.firstname = 'jimmy' and prpr.Name like '%tire%';

--but we can use CTE's to make it look less jarring
with OrderHeader as
(
    select salesorderid, customerid, OrderDate
    from sales.SalesOrderHeader
    where datepart(month, OrderDate)=7
),
Product as 
(
    select productid, name
    from Production.Product
    where name like '%tire%'
)
select pp.firstname, pp.lastname, prpr.Name, ssoh.OrderDate
from Person.Person as pp
inner join Person.BusinessEntityAddress as pbea on pbea.BusinessEntityId = pp.BusinessEntityId
inner join Person.Address as pa on pa.AddressID = pbea.AddressID
inner join Sales.Customer as sc on sc.CustomerID = pp.BusinessEntityID
inner join OrderHeader as ssoh on ssoh.CustomerID = sc.CustomerID
inner join Sales.SalesOrderDetail as ssod on ssod.SalesOrderID = ssoh.SalesOrderID
inner join Product as prpr on prpr.ProductID = ssod.ProductID
where pp.firstname = 'jimmy' and prpr.Name like '%tire%'

--Union
--find all firstnames that are also lastnames, this is a "intersect" done with a join
select pp1.firstname, pp2.lastname
from person.Person as pp1
inner join person.person as pp2
on pp1.firstname = pp2.LastName;

--here it is with an intersect
select firstname
from Person.Person
INTERSECT
select lastname
from person.person;