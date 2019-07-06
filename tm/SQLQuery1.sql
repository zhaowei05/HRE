


create table UserInfo --用户表
(
UserID	Int	 primary key identity(1,1),--	序号(主键)
DepartmentID  	Int,			--部门编号
RoleID	Int	,		--角色编号（1.总经理 2.人事经理 3.人事助理 4.部门经理 5.员工）
UserNumber	Varchar(50)	,	--用户编号
LoginName	Varchar(50)	,	--登陆名
LoginPwd	Varchar(50)	,	--密码
UserName	Varchar(50)	,	--真实姓名
UserAge	Int		,--年龄
UserSex	Int		,--性别 （1.男  0.女）
UserTel	Varchar(11)	,--电话
UserAddress	Varchar(100),--家庭地址
UserIphone	Varchar(11)	,--手机
UserRemarks	Varchar(200),--备注
UserStatr	int	,--是否可用（0.不可登陆 1.可登陆）
EntryTime	Datetime,	--最后登陆时间
DimissionTime	Datetime,	--入职时间
BasePay  	money	--薪资
)

create table Department --部门表
(
DepartmentID	Int	primary key identity(1,1),	--部门编号(主键)
DepartmentName	varchar(50)	,	--部门名称
DepartmentRemarks	int	--备注
)

create table Role --角色表
(
	RoleID	Int	primary key identity(1,1),--角色编号(主键)
	RoleName	varchar(50)	,	--角色名称
	RoleNumber	varchar(200),--角色权限百分比
)

create table Assessment --业绩评定表
(
    AssessmentID	Int	primary key identity(1,1),--业绩评定编号(主键)
	PerformanceTime	DateTime	,		--考评日期
	UserID	int		,--评定人
	WorkSummary	varchar(max)	,	--总结
	UpperGoal	varchar(max)	,	--完成度
	CompletionDegree	float		,	--互评分数
	ExaminationItems	Varchar(100)	,	--下阶段目标
	NextStageObjectives	varchar(100)	,	--上阶段目标
	PerformanceScore	Float		,	--最终总分
	comments	Varchar		,	--主管评论
	perstate	int			--审核状态
)

create table AttendanceSheet --考勤信息表
(
  AttendanceID	Int	primary key identity(1,1),	--考勤编号(主键)
AttendanceStartTime  	DateTime,--考勤时间
AttendanceType	Int	,--考勤状态
UserID	Int		,--用户编号
ClockTime	DateTime	,	--第一次打卡
ClockOutTime	DateTime,	--第二次打卡
Workinghours int		,	--工作小时
remake	Varchar(200),	--备注
Late	Int			,--迟到次数
Absenteeism	int			--考勤次数

)

create table CategoryItems --字典表
(
	CID	Int	primary key identity(1,1),	--编号(主键)
	C_Category   	Varchar	,	--表名
	CI_ID          	int		,	--ID
	CI_Name       	Varchar			--字典名称
)


create table Leave --请假表
(
	LeaveID        	Int		primary key identity(1,1),	--请假编号(主键)
	UserID	     	Int		,	--用户编号
	LeaveState     	int		,	--审批状态
	LeaveTime          	DateTime	,	--请假时间
	LeaveStartTime		DateTime	,	--请假起始时间
	LeaveEndTime       	DateTime	,	--结束时间
	LeaveHalfDay       	Varchar(20)	,	--时间段（上午或下午）
	LeaveDays          	Int			   ,--请假天数
	LeaveReason        	Varchar(250)	,	--请假原因
	ApproverID         	Int			,   --审批编号
	ApprovalTime       	DateTime	,	--审批时间
	ApproverReason     	Varchar(250)	--审批备注

)


create table Notice --公告表
(
	NoticeID             	Int	 primary key identity(1,1),	--公告编号(主键)
	NoticeType           	int		,	--公告类型
	NoticeTitle          	Varchar(250)	,	--公告标题
	NoticeContent        	Varchar(500)	,	--公告内容
	UserID			Int	,		--发布人
	NoticeStateTime    	dateTime	,		--通知起始时间
	NoticeEndTime      	Datetime	,		--结束时间
	NoticeState		Int		,	--通知紧急状态（可参考字典表）

)

create table Overtime --加班申请表
(
    OvertimeID           	Int	 primary key identity(1,1),	--加班编号(主键)
	OvertimeStateTime    	Datetime,			--加班起始时间
	OvertimeEndTime      	Datetime,			--加班结束时间
	OvertimeDuration		Int,			--申请状态
	UserID               	Int,			--用户编号
	ApplyTime				Datetime,			--审批时间
	OvertimeState        	Int	,		--审批进度
	ApproverReason varchar --审批内容
)

create table PayRise --工资增长表
(
	PayRiseID              	Int	 primary key identity(1,1),	--工资增长编号(主键)
	UserID	int		,	--用户编号
	PayRiseMoney			Money,			--工资收入
	Reason               	Varchar(Max),		--原因
	ApplicationTime      	Datetime,			--申请时间
	ApprovalContent      	varchar(500),		--批准内容
	ApprovalState        	int,			--批准状态
	ApprovalTime       	Datetime			--批准时间

)

create table PaySlipID--工资表
(
    id	Int		primary key identity(1,1),	--编号(主键)
	UserID	int	,	--用户编号
	BasicSalary    	Money,			--基本工资
	AttendanceBonus      	money,			--考勤奖金
	Fine                 	Money,			--罚款
	SalaryTime	Datetime,			--发工资时间
	SalarySum	money			--最后工资

)

create table PaySlip  --工资单表
(
	PaySlipID   Int	primary key identity(1,1),	--工资编号(主键)
	UserID	int,	--员工编号
	Prize	Money,			--全勤奖金
	LeaveMoney	Money,			--请假扣钱
	OvertimeMoney	Money,			--加班奖金
	LateMoney	Money,		--迟到
	AdvanceMoney	Money,			--早退
	Absence				Money,			--缺勤
	fine		Money,			--罚款
	Sa_Bonus	Money,			--业绩奖金
	Sa_Time	Datetime,			--工资结算时间
	Sa_TotalSalary 	Money			--合计工资
)

create table SystemLog--日志表
(
    LogID	Int		primary key identity(1,1),	--登陆编号(主键)
	userID	int,	--用户编号
	LogTime              	Datetime,			--登陆时间
	LogOperation         	Varchar(500)	,	--操作内容

)