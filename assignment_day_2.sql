select * from policies;
select * from policyAssignments;
select * from claims;
drop table claims;
create table claims(
claimId int primary key,
assignmentId int,
claimDate date,
claimAmount decimal(10,2),
claimStatus varchar(12),
foreign key(assignmentId) references policyAssignments(assignmentId)
)


--1
select * from customers;
--2
select customerId,policyId,startDate,endDate from policyAssignments;
--3
select * from policies where policyType='Health';
--4
select * from policies where premiumAmount>10000 and durationYears=1;
--5
select distinct city from agents;
--6
select * from policies where policyType='Health' or policyType='Life' or policyType='Motor';
--7
select * from policies where policyType in ('Health','Life','Motor');
--8
select * from customers where dateofBirth>='2001-1-1' and dateofBirth<='2020-12-31';
--9
select * from customers where dateOfBirth between '2001-1-1' and '2020-12-31';
--10
select * from claims where claimStatus='Rejected';
--11
select * from agents where city like '_a%';
--12
