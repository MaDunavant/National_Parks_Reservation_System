delete from reservation

declare @campsiteId int = 1
insert into reservation values (@campsiteId, 'name', '2019-01-01', '2019-02-01', null)
declare @newReservationId int = (select @@identity)

declare @parkCount int = (select count(*) from park)

declare @parkId int = 1
declare @campgroundCount int = (select count(*) from campground where park_Id = @parkId)

declare @campgroundId int = 1
declare @campsiteCount int = (select count(*) from site where campground_Id = @campgroundId)

declare @newOpenFrom int = 3
declare @newOpenTo int = 10
insert into campground values (@parkId, 'doesnt matter', @newOpenFrom, @newOpenTo, 10.00)
declare @newCampgroundId int = (select @@identity)

select @campsiteId as campsiteId, @newReservationId as newReservationId, @parkCount as parkCount, @parkId as parkID, @campgroundCount as campgroundCount, @campgroundId as campgroundId, @campsiteCount as campsiteCount, @newOpenFrom as newOpenFrom, @newOpenTo as newOpenTo, @newCampgroundId as newCampgroundId