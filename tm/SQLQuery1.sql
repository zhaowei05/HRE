create database HRE
go
use HRE
go

--�û���
create table UserInfo
(
	UserID	Int		primary key identity(1,1),  --���(����)
	DepartmentID  	Int	,		--���ű��
	RoleID	Int	,		--��ɫ��ţ�1.�ܾ��� 2.���¾��� 3.�������� 4.���ž��� 5.Ա����
	UserNumber	Varchar	(50),		--�û����
	LoginName	Varchar	(50),	--��½��
	LoginPwd	Varchar	(50),		--����
	UserName	Varchar	(50),		--��ʵ����
	UserAge	Int		,	--����
	UserSex	Int		,	--�Ա� ��1.��  0.Ů��
	UserTel	varchar	(11),		--�绰
	UserAddress	Varchar	(100),		--��ͥ��ַ
	UserIphone	Varchar	(11),		--�ֻ�
	UserRemarks	Varchar	(200),		--��ע
	UserStatr	int	,		--�Ƿ���ã�0.���ɵ�½ 1.�ɵ�½��
	EntryTime	Datetime,			--����½ʱ��
	DimissionTime	Datetime,			--��ְʱ��
	BasePay  	money			--н��
)

--���ű�