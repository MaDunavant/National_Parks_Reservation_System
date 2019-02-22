delete from reservation

declare @campsiteId int = 1
insert into reservation values (@campsiteId, 'name', '2019-03-01', '2019-03-04', null)
declare @newReservationId int = (select @@identity)

declare @parkCount int = (select count(*) from park)

declare @parkId int = 1
declare @campgroundCount int = (select count(*) from campground where park_Id = @parkId)

declare @campgroundId int = 1
declare @campsiteCount int = (select count(*) from site where campground_Id = @campgroundId)

select @campsiteId as campsiteId, @newReservationId as newReservationId, @parkCount as parkCount, @parkId as parkID, @campgroundCount as campgroundCount, @campgroundId as campgroundId, @campsiteCount as campsiteCount