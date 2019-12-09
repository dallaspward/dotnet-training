use master;
go

--views
create view vw_Person
as 
select firstname, lastname
from Person.Person;
go

select * from vw_Person;
go 

--function
--tabular function
create function fn_Person(@first nvarchar(50))
returns TABLE
as
RETURN
select firstname, lastname
from Person.Person
where FirstName = @first;
go

--scalar function
create function fn_FullName(@first nvarchar(50), @middle nvarchar(50), @last nvarchar(50))
returns nvarchar(200)
as 
begin
    return @first + coalesce(' ' + @middle, '',null,null) + ' ' + @last --if middle name is not null do the first half of parenthesis, if it is null use the second half
end;
go

select dbo.fn_FullName(firstname, null, lastname) as full_name from fn_Person('joshua');
go

-- stored procedure
-- the content of a stored procedure is cached, so each time it is called, the only part of the procedure that is run are any changes in the result set/when the cache time runs out
create procedure sp_InsertName(@first nvarchar(50), @middle nvarchar(50), @last nvarchar(50))
as 
begin
    begin transaction
        begin try
            declare @mname nvarchar(50) = @middle

            if(@middle is null)
            begin
                set @mname = '' 
            END

            checkpoint --saves at this point, so if an error occurs we don't lose anything up to this point

            insert into Person.Person(FirstName, LastName, MiddleName)
            values (@first, @last, @mname)

            commit transaction
        end TRY

        begin CATCH
            print error_message()
            print error_severity() --level within the state, how critical is the error within the state
            print error_state() --internal error or external error, user generated problem or database generated
            print error_number()
            rollback transaction
        end catch
end;

execute sp_InsertName 'fred', 'jebediah', 'belotte';
go

--triggers
--triggers are events in sql, a special query that lets a table know how to handle a dml statement
--3 types: before, for, instead of 
--before will run its query before the dml statement that raised the event
--for will run its query in parallel with the dml statement
--instead of will run its query instead of the dml statement

create trigger tr_InsertName 
on Person.Person
instead of INSERT
as 
update pp
set firstname = inserted.firstname
from Person.Person as pp
where pp.BusinessEntityID = inserted BusinessEntityID