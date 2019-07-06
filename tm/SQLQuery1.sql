


create table UserInfo --�û���
(
UserID	Int	 primary key identity(1,1),--	���(����)
DepartmentID  	Int,			--���ű��
RoleID	Int	,		--��ɫ��ţ�1.�ܾ��� 2.���¾��� 3.�������� 4.���ž��� 5.Ա����
UserNumber	Varchar(50)	,	--�û����
LoginName	Varchar(50)	,	--��½��
LoginPwd	Varchar(50)	,	--����
UserName	Varchar(50)	,	--��ʵ����
UserAge	Int		,--����
UserSex	Int		,--�Ա� ��1.��  0.Ů��
UserTel	Varchar(11)	,--�绰
UserAddress	Varchar(100),--��ͥ��ַ
UserIphone	Varchar(11)	,--�ֻ�
UserRemarks	Varchar(200),--��ע
UserStatr	int	,--�Ƿ���ã�0.���ɵ�½ 1.�ɵ�½��
EntryTime	Datetime,	--����½ʱ��
DimissionTime	Datetime,	--��ְʱ��
BasePay  	money	--н��
)

create table Department --���ű�
(
DepartmentID	Int	primary key identity(1,1),	--���ű��(����)
DepartmentName	varchar(50)	,	--��������
DepartmentRemarks	int	--��ע
)

create table Role --��ɫ��
(
	RoleID	Int	primary key identity(1,1),--��ɫ���(����)
	RoleName	varchar(50)	,	--��ɫ����
	RoleNumber	varchar(200),--��ɫȨ�ްٷֱ�
)

create table Assessment --ҵ��������
(
    AssessmentID	Int	primary key identity(1,1),--ҵ���������(����)
	PerformanceTime	DateTime	,		--��������
	UserID	int		,--������
	WorkSummary	varchar(max)	,	--�ܽ�
	UpperGoal	varchar(max)	,	--��ɶ�
	CompletionDegree	float		,	--��������
	ExaminationItems	Varchar(100)	,	--�½׶�Ŀ��
	NextStageObjectives	varchar(100)	,	--�Ͻ׶�Ŀ��
	PerformanceScore	Float		,	--�����ܷ�
	comments	Varchar		,	--��������
	perstate	int			--���״̬
)

create table AttendanceSheet --������Ϣ��
(
  AttendanceID	Int	primary key identity(1,1),	--���ڱ��(����)
AttendanceStartTime  	DateTime,--����ʱ��
AttendanceType	Int	,--����״̬
UserID	Int		,--�û����
ClockTime	DateTime	,	--��һ�δ�
ClockOutTime	DateTime,	--�ڶ��δ�
Workinghours int		,	--����Сʱ
remake	Varchar(200),	--��ע
Late	Int			,--�ٵ�����
Absenteeism	int			--���ڴ���

)

create table CategoryItems --�ֵ��
(
	CID	Int	primary key identity(1,1),	--���(����)
	C_Category   	Varchar	,	--����
	CI_ID          	int		,	--ID
	CI_Name       	Varchar			--�ֵ�����
)


create table Leave --��ٱ�
(
	LeaveID        	Int		primary key identity(1,1),	--��ٱ��(����)
	UserID	     	Int		,	--�û����
	LeaveState     	int		,	--����״̬
	LeaveTime          	DateTime	,	--���ʱ��
	LeaveStartTime		DateTime	,	--�����ʼʱ��
	LeaveEndTime       	DateTime	,	--����ʱ��
	LeaveHalfDay       	Varchar(20)	,	--ʱ��Σ���������磩
	LeaveDays          	Int			   ,--�������
	LeaveReason        	Varchar(250)	,	--���ԭ��
	ApproverID         	Int			,   --�������
	ApprovalTime       	DateTime	,	--����ʱ��
	ApproverReason     	Varchar(250)	--������ע

)


create table Notice --�����
(
	NoticeID             	Int	 primary key identity(1,1),	--������(����)
	NoticeType           	int		,	--��������
	NoticeTitle          	Varchar(250)	,	--�������
	NoticeContent        	Varchar(500)	,	--��������
	UserID			Int	,		--������
	NoticeStateTime    	dateTime	,		--֪ͨ��ʼʱ��
	NoticeEndTime      	Datetime	,		--����ʱ��
	NoticeState		Int		,	--֪ͨ����״̬���ɲο��ֵ��

)

create table Overtime --�Ӱ������
(
    OvertimeID           	Int	 primary key identity(1,1),	--�Ӱ���(����)
	OvertimeStateTime    	Datetime,			--�Ӱ���ʼʱ��
	OvertimeEndTime      	Datetime,			--�Ӱ����ʱ��
	OvertimeDuration		Int,			--����״̬
	UserID               	Int,			--�û����
	ApplyTime				Datetime,			--����ʱ��
	OvertimeState        	Int	,		--��������
	ApproverReason varchar --��������
)

create table PayRise --����������
(
	PayRiseID              	Int	 primary key identity(1,1),	--�����������(����)
	UserID	int		,	--�û����
	PayRiseMoney			Money,			--��������
	Reason               	Varchar(Max),		--ԭ��
	ApplicationTime      	Datetime,			--����ʱ��
	ApprovalContent      	varchar(500),		--��׼����
	ApprovalState        	int,			--��׼״̬
	ApprovalTime       	Datetime			--��׼ʱ��

)

create table PaySlipID--���ʱ�
(
    id	Int		primary key identity(1,1),	--���(����)
	UserID	int	,	--�û����
	BasicSalary    	Money,			--��������
	AttendanceBonus      	money,			--���ڽ���
	Fine                 	Money,			--����
	SalaryTime	Datetime,			--������ʱ��
	SalarySum	money			--�����

)

create table PaySlip  --���ʵ���
(
	PaySlipID   Int	primary key identity(1,1),	--���ʱ��(����)
	UserID	int,	--Ա�����
	Prize	Money,			--ȫ�ڽ���
	LeaveMoney	Money,			--��ٿ�Ǯ
	OvertimeMoney	Money,			--�Ӱཱ��
	LateMoney	Money,		--�ٵ�
	AdvanceMoney	Money,			--����
	Absence				Money,			--ȱ��
	fine		Money,			--����
	Sa_Bonus	Money,			--ҵ������
	Sa_Time	Datetime,			--���ʽ���ʱ��
	Sa_TotalSalary 	Money			--�ϼƹ���
)

create table SystemLog--��־��
(
    LogID	Int		primary key identity(1,1),	--��½���(����)
	userID	int,	--�û����
	LogTime              	Datetime,			--��½ʱ��
	LogOperation         	Varchar(500)	,	--��������

)