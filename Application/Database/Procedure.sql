
CREATE OR REPLACE view 'ViewProduct_0256' 
as
	select *,(
			select name 
			from 'Category_0256' c
			where p.'categoryId' = c.id
			and c.'isTrash' is false 
			and c.'isPublic' is true
		) as 'categoryName',(
			select name 
			from 'Brand_0256' b
			where p.'brandId' = b.id
			and b.'isTrash' is false 
			and b.'isPublic' is true
		) as 'brandName',(
			select url 
			from 'Image_0256' i,'ProductImage_0256' pi
			where pi.'imageId' = i.id
			and pi.'productId' = p.id
			and i.'isTrash' is false 
			and i.'isPublic' is true
			and pi.'isDefault' is true
			and pi.'isTrash' is false 
			and pi.'isPublic' is true
			order by i.id limit 1
		) as 'imageUrl',(
			select avg(pr.vote)
			from 'ProductRating_0256' pr
			where p.id = pr.'productId'
			and pr.'isTrash' is false 
			and pr.'isPublic' is true
		) as 'rating',(
			select name
			from 'ProductType_0256' pt
			where p.'typeId' = pt.id
			and pt.'isTrash' is false 
			and pt.'isPublic' is true
		) as 'typeName'
from 'Product_0256' p;
-------------------------------------------------------

CREATE OR REPLACE view 'ViewProductImage_0256' 
as
	select *,(
		select url from 'Image_0256' i
		where pi.'imageId' = i.id
	) as 'imageUrl' 
	from 'ProductImage_0256' pi;
--------------------------------------------------

CREATE OR REPLACE view 'ViewCategory_0256' 
as
	select *,(
			select url 
			from 'Image_0256' i
			where c.'imageId' = i.id
			and i.'isTrash' is false 
			and i.'isPublic' is true
		) as 'imageUrl'
	from 'Category_0256' c;
-------------------------------------------------------


CREATE OR REPLACE view 'ViewBrand_0256' 
as
	select *,(
			select url 
			from 'Image_0256' i
			where b.'imageId' = i.id
			and i.'isTrash' is false 
			and i.'isPublic' is true
		) as 'imageUrl'
	from 'Brand_0256' b;
------------------------------------------------------------
-------------------------------------------------------

CREATE OR REPLACE view 'ViewSlider_0256' 
as
	select *,(
			select url 
			from 'Image_0256' i
			where s.'imageId' = i.id
			and i.'isTrash' is false 
			and i.'isPublic' is true
		) as 'imageUrl'
	from 'Slider_0256' s;

-------------------------------------------------------

CREATE OR REPLACE view 'ViewUser_0256' 
as
	select *,(
			select url 
			from 'Image_0256' i
			where u.'imageId' = i.id
			and i.'isTrash' is false 
			and i.'isPublic' is true
		) as 'imageUrl'
		,(
			select name
			from 'UserType_0256' ut
			where u.'typeId' = ut.id
		) as 'typeName'
	from 'User_0256' u;
----------------------------------------------------------------

CREATE OR REPLACE view 'ViewStatisUser_0256'
as
	select 
		'createDate',
		count(id) total
	from 'ViewUser_0256'
	where 'isTrash' is false 
	group by 'createDate',CAST('createDate' as date);
------------------------------------------------------------------------------

CREATE OR REPLACE view 'ViewOrder_0256' 
as
	select o.id id,
		o.'createDate',
		o.'voucherSale',
		o.'isPublic',
		o.'isTrash',
		o.'userId',
		u.'firstName',
		u.'lastName',
		u.email,
		u.phone,
		o.'statusId',(
			select name 
			from 'OrderStatus_0256' os
			where o.'statusId' = os.id
		) as 'statusName',
		location,(
			select sum(price * quantity)
			from 'OrderDetail_0256' od
			where od.'orderId' = o.id
		) as 'totalPrice'
	from 'Order_0256' o,'User_0256' u
	where o.'userId' = u.id;


	------------------------------------------------------------------------------

CREATE OR REPLACE view 'ViewOrderDetail_0256' 
as 
	select o.id,
		o.'orderId',
		o.'productId',
		o.price,
		o.quantity,
		o.'isPublic',
		o.'isTrash',
		p.name,
		p.alias,
		p.'imageUrl',
		p.'categoryName',
		p.'brandName',
		p.'typeName',
		p.rating
	from 'OrderDetail_0256' o,'ViewProduct_0256' p
	where o.'productId' = p.id;

 
CREATE OR REPLACE view 'ViewStatisOrder_0256'
as
	select 
		'createDate',
		'statusName',
		count(id) total 
	from 'ViewOrder_0256'
	where 'isTrash' is false 
	group by 'createDate',CAST('createDate' as date),'statusName';
 

