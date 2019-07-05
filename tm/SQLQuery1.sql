create database HRE
go
use HRE
go

--用户表
create table UserInfo
(
	UserID	Int		primary key identity(1,1),  --序号(主键)
	DepartmentID  	Int	,		--部门编号
	RoleID	Int	,		--角色编号（1.总经理 2.人事经理 3.人事助理 4.部门经理 5.员工）
	UserNumber	Varchar	(50),		--用户编号
	LoginName	Varchar	(50),	--登陆名
	LoginPwd	Varchar	(50),		--密码
	UserName	Varchar	(50),		--真实姓名
	UserAge	Int		,	--年龄
	UserSex	Int		,	--性别 （1.男  0.女）
	UserTel	varchar	(11),		--电话
	UserAddress	Varchar	(100),		--家庭地址
	UserIphone	Varchar	(11),		--手机
	UserRemarks	Varchar	(200),		--备注
	UserStatr	int	,		--是否可用（0.不可登陆 1.可登陆）
	EntryTime	Datetime,			--最后登陆时间
	DimissionTime	Datetime,			--入职时间
	BasePay  	money			--薪资
)

--部门表