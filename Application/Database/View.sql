

	drop view if exists ViewProduct_0256

	create view ViewProduct_0256 
as
	select *,(
			select name 
			from Catery_0256
			where Product_0256s.cateryId = Catery_0256s.id
			and Catery_0256s.isTrash = 0
			and Catery_0256s.isPublic = 1
		) cateryName,(
			select name 
			from Brand_0256
			where Product_0256s.brandId = Brand_0256s.id
			and Brand_0256s.isTrash = 0
			and Brand_0256s.isPublic = 1
		) brandName,(
			select top 1 url 
			from Image_0256,ProductImage_0256
			where ProductImage_0256s.imageId = Image_0256s.id
			and ProductImage_0256s.productId = Product_0256s.id
			and Image_0256s.isTrash = 0
			and Image_0256s.isPublic = 1
			and ProductImage_0256s.isDefault = 1
			and ProductImage_0256s.isTrash = 0
			and ProductImage_0256s.isPublic = 1
		) imageUrl,(
			select avg(ProductRating_0256s.vote)
			from ProductRating_0256
			where Product_0256s.id = ProductRating_0256s.productId
			and ProductRating_0256s.isTrash = 0
			and ProductRating_0256s.isPublic = 1
		) rating,(
			select name
			from ProductType_0256
			where Product_0256s.typeId = ProductType_0256s.id
			and ProductType_0256s.isTrash = 0
			and ProductType_0256s.isPublic = 1
		) typeName
from Product_0256
-------------------------------------------------------

	drop view if exists ViewProductImage_0256

	create view ViewProductImage_0256 
as
	select *,(select url from Image_0256 where ProductImage_0256s.imageId = Image_0256s.id) imageUrl from ProductImage_0256
--------------------------------------------------

	drop view if exists ViewCatery_0256

	create view ViewCatery_0256 
as
	select *,(
			select url 
			from Image_0256
			where Catery_0256s.imageId = Image_0256s.id
			and Image_0256s.isTrash = 0
			and Image_0256s.isPublic = 1
		) imageUrl
	from Catery_0256
-------------------------------------------------------


	drop view if exists ViewBrand_0256

	create view ViewBrand_0256 
as
	select *,(
			select url 
			from Image_0256
			where Brand_0256s.imageId = Image_0256s.id
			and Image_0256s.isTrash = 0
			and Image_0256s.isPublic = 1
		) imageUrl
	from Brand_0256
------------------------------------------------------------
-------------------------------------------------------

	drop view if exists ViewSlider_0256

	create view ViewSlider_0256 
as
	select *,(
			select url 
			from Image_0256
			where Slider_0256s.imageId = Image_0256s.id
			and Image_0256s.isTrash = 0
			and Image_0256s.isPublic = 1
		) imageUrl
	from Slider_0256

-------------------------------------------------------

	drop view if exists ViewUser_0256

	create view ViewUser_0256 
as
	select *,(
			select url 
			from Image_0256
			where User_0256s.imageId = Image_0256s.id
			and Image_0256s.isTrash = 0
			and Image_0256s.isPublic = 1
		) imageUrl
		,(
			select name
			from UserType_0256
			where User_0256s.typeId = UserType_0256s.id
		) typeName
	from User_0256
----------------------------------------------------------------

drop view if exists ViewStatisUser_0256
 
create view ViewStatisUser_0256
as
	select 
		createDate,
		count(id) total
	from ViewUser_0256
	where isTrash = 0
	group by createDate,CAST(createDate as date)
------------------------------------------------------------------------------

	drop view if exists ViewOrder_0256

	create view ViewOrder_0256 
as
	select Order_0256s.id id,
		userId,
		Order_0256s.createDate,
		voucherSale,
		Order_0256s.isPublic,
		Order_0256s.isTrash,
		firstName,
		lastName,
		email,
		phone,
		statusId,(
			select name 
			from OrderStatus_0256
			where statusId = id
		) statusName,
		location,(
			select sum(price * quantity)
			from OrderDetail_0256
			where orderId = Order_0256s.id
		) totalPrice
	from Order_0256,User_0256
	where Order_0256s.userId = User_0256s.id


	------------------------------------------------------------------------------

	drop view if exists ViewOrderDetail_0256

	create view ViewOrderDetail_0256 
as 
	select o.id,
		o.orderId,
		o.productId,
		o.price,
		o.isPublic,
		o.isTrash,
		name,
		alias,
		imageUrl,
		cateryName,
		brandName,
		typeName,
		rating,
		quantity
	from OrderDetail_0256 o,ViewProduct_0256 p
	where o.productId = p.id

 
drop view if exists ViewStatisOrder_0256
 
create view ViewStatisOrder_0256
as
	select 
		createDate,
		statusName,
		count(id) total 
	from ViewOrder_0256
	where isTrash = 0
	group by createDate,CAST(createDate as date),statusName
 

