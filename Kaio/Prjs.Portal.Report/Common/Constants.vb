Public Class Constants
#Region "Database"
    Public Class DatabaseConnstr
        Public Class MSSQL

        End Class
        Public Class MySQL
          

        End Class
        Public Class Oracle
       

        End Class
    End Class
#End Region
#Region "Log Levels"
    Public Class LogLevel
        Public Const _Debug As String = "DEBUG"
        Public Const _Error As String = "ERROR"
        Public Const _Fatal As String = "FATAL"
        Public Const _Info As String = "INFO"
        Public Const _Warn As String = "WARN"

    End Class
#End Region
#Region "Field Database"
    Public Class DatabaseField
        Public Const Is_Status_Locked As Integer = 0
        Public Const Is_Status_UnLock As Integer = 1
    End Class
#End Region
#Region "Action"
    Public Class Action
        Public Const Insert As String = "Insert"
        Public Const Update As String = "Update"
        Public Const Delete As String = "Delete"
        Public Const Search As String = "Search"
        Public Const Export As String = "Export"
    End Class
#End Region
#Region "Template"
    Public Class Templates
        Public Class Email
            Public Const UserInformation As String = "~\Templates\Email\UserInformation.xslt"
        End Class
    End Class

#End Region
#Region "Alert Message"
    Public Class AlertInfo
        Public Const ConfirmDelete As String = "Xóa dữ liệu ?"
        Public Const ErrorExcute As String = "Lỗi thao tác dữ liệu !"
        Public Const ErrorCode As String = "Mã lỗi: "
        Public Const ExcuteSuccess As String = "Cập nhật dữ liệu thành công !"
        Public Const ZeroRecord As String = "Không có dữ liệu !"
        Public Const ExistRecordAdd As String = "Thông tin này đã tồn tại trên hệ thống !"
        Public Const ExistRecordDelete As String = "Không thể xóa dữ liệu. Tồn tại bản ghi liên quan đến dữ liệu này !"

    End Class
#End Region
#Region "IsAccess Right System"
    Public Class PrivilegesSystems
        Public Const IsSignIn As Integer = 1
        Public Const IsSignOut As Integer = 0
        Public Const IsAdministrator As Integer = 1
        Public Const IsView As Integer = 1
        Public Const IsUpdate As Integer = 2
        Public Const IsDelete As Integer = 3

    End Class
#End Region
#Region "Regular Expressions"
    Public Class Regex
        Public Const vPattern_Aphabet As String = "\w"
        Public Const vPattern_None_Aphabet As String = "\W"
        Public Const vPattern_Email As String = "\w+.@\w+.\w{2,4}" ' ^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$
        Public Const vPattern_Phone_National As String = "0\d{9,10}"
        Public Const vPattern_Phone_Intenational As String = "84\d{10,11}"
        Public Const vPattern_Password As String = "^(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$"
        Public Const vPattern_Numberic As String = "\d"

    End Class
#End Region
#Region "Encrypt"
    Public Class Encrypt
        Public Const Encrypt_MD5 As String = "MD5"
        Public Const Zero As String = "w+cpdiT6wL4="
    End Class
#End Region
#Region "Channel"
    Public Class Channel
        Public Class Id
            Public Const Home As Integer = 0
            Public Const Administrator As Integer = 1
            Public Const AndroidApps As Integer = 2
            Public Const Ccare As Integer = 3

            Public Const S2 As Integer = 4
            Public Const Vinabox As Integer = 5
            Public Const GamePortal As Integer = 6
            Public Const Vishare As Integer = 8
            Public Const SimToolKit As Integer = 9
            Public Const Billing As Integer = 10
            Public Const CustomerInfo As Integer = 11
            Public Const Charging As Integer = 12
            Public Const MGame As Integer = 14
            Public Const KPI As Integer = 15
            Public Const ContractInfo As Integer = 20

        End Class
        Public Class Code
            Public Const Administrator As String = "2ba3a3fd0d3773d2d02cadbc708f7a3d" 'Channel-1
            Public Const AndroidApps As String = "2c7933ca0543877c0e975a0f40cd40cf" 'Channel-2
            Public Const Ccare As String = "ba8ae4752b10aad63de1500ff667c88e" 'Channel-3

            Public Const S2 As String = "2f0d4815f8c0f79b340950ab78ef6adb" 'Channel-4
            Public Const Vinabox As String = "a8c0149052789e5e705ba26084eeeafd" 'Channel-5
            Public Const GamePortal As String = "6d4727b02e106f11324048cdc0b14f3b" 'Channel-6
            Public Const Vishare As String = "5f818ead0825e4562732b33acd78307d" 'Channel-8
            Public Const SimToolKit As String = "53043b94b309e8e9c246d8b93da449a4" ' Channel-9
            Public Const Billing As String = "841db316461eb28b0e62f687caeb744c" 'Channel-10
            Public Const CustomerInfo As String = "97b851381117d8131466b420b991aeeb" 'Channel-11
            Public Const Charging As String = "2acb068a481d6b561b0b5c803f15230a" ' Channel-12
            Public Const MGame As String = "0822a4af199e03c209d05c239ed6eaad" ' Channel-14
            Public Const KPI As String = "988a403a115e4c6ebfd8efdf83864b0a" 'Channel-15
            Public Const ContractInfo As String = "7ded01ff583d4f0a5a1212cec7dd1f4c" 'Channel-20
        End Class
        Public Class Text
            Public Const HQPortal As String = "Apptel Media Coporation"
            Public Const Home As String = "Home"
            Public Const Administrator As String = "Administrator"
            Public Const AndroidApps As String = "Android Apps"
            Public Const Ccare As String = "Ccare"

            Public Const S2 As String = "S2"
            Public Const Vinabox As String = "Vinabox"
            Public Const GamePortal As String = "Game Portal"
            Public Const SimToolKit As String = "STK"
            Public Const Vishare As String = "Vishare"
            Public Const Billing As String = "Đối soát, thanh toán"
            Public Const CustomerInfo As String = "B2C"
            Public Const Charging As String = "Charging"
            Public Const MGame As String = "M-GAME"
            Public Const KPI As String = "KPI"
            Public Const ContractInfo As String = "Hợp đồng"
        End Class
    End Class
#End Region
#Region "Service Info"
    Public Class ServiceInfo
        Public Class Id
            Public Const SMS As Integer = 1
            Public Const TC As Integer = 2
            Public Const BN As Integer = 3
            Public Const Vishare As Integer = 4
            Public Const Vinabox As Integer = 5
            Public Const NHAC As Integer = 6
            Public Const GAME As Integer = 7
            Public Const LiveNews As Integer = 8
            Public Const STK As Integer = 9
            Public Const GamePortal As Integer = 10
            Public Const Voicechat As Integer = 11
            Public Const IWEB As Integer = 12
            Public Const S2 As Integer = 13
            Public Const MGame As Integer = 14
            Public Const PregnancyDiary As Integer = 15
        End Class
        Public Class Code
            Public Const SMS As String = "SMS"
            Public Const TC As String = "TC"
            Public Const BN As String = "BN"
            Public Const Vishare As String = "Vishare"
            Public Const Vinabox As String = "Vinabox"
            Public Const NHAC As String = "NHAC"
            Public Const GAME As String = "GAME"
            Public Const LiveNews As String = "LiveNews"
            Public Const STK As String = "STK"
            Public Const GamePortal As String = "GamePortal"
            Public Const Voicechat As String = "Voicechat"
            Public Const IWEB As String = "IWEB"
            Public Const S2 As String = "S2"
            Public Const MGame As String = "MGame"
            Public Const PregnancyDiary As String = "PregnancyDiary"
        End Class
        Public Class Text
            Public Const SMS As String = "SMS"
            Public Const TC As String = "Thẻ cào"
            Public Const BN As String = "Brandname"
            Public Const Vishare As String = "Vishare"
            Public Const Vinabox As String = "Vinabox"
            Public Const NHAC As String = "Nhạc"
            Public Const GAME As String = "Game"
            Public Const LiveNews As String = "LiveNews"
            Public Const STK As String = "STK"
            Public Const GamePortal As String = "Game Portal"
            Public Const Voicechat As String = "Voice Chat"
            Public Const IWEB As String = "Iweb"
            Public Const S2 As String = "Subscription Service"
            Public Const MGame As String = "M-Game"
            Public Const PregnancyDiary As String = "Pregnancy Diary"
        End Class
    End Class
#End Region
#Region "Url"
    Public Class Url
#Region "Global"
        Public Class _Global
            Public Const Index As String = "/index.aspx"
            Public Const Login As String = "/login.aspx"
            Public Const Copyright As String = "/copyright.aspx"
            Public Const Banner As String = "/banner.aspx"
            Public Const Footer As String = "/footer.aspx"
            Public Const Menuleft As String = "/menuleft.aspx"
            Public Const AccessDenied As String = "/accessDenied.aspx"
        End Class
#End Region
#Region "Administrator"
        Public Class _Admin
            Public Const AdminUrlList As String = "/Administrator/Url/AdminUrlList.aspx"
            Public Const AdminUrlEdit As String = "/Administrator/Url/AdminUrlEdit.aspx"
            Public Const AdminGroupUserList As String = "/Administrator/Group/AdminGroupUserList.aspx"
            Public Const AdminGroupUserEdit As String = "/Administrator/Group/AdminGroupUserEdit.aspx"
            Public Const AdminMobileOperatorList As String = "/Administrator/DictIndex/AdminMobileOperatorList.aspx"
            Public Const AdminMobileOperatorEdit As String = "/Administrator/DictIndex/AdminMobileOperatorEdit.aspx"
            Public Const AdminServiceInfoList As String = "/Administrator/DictIndex/AdminServiceInfoList.aspx"
            Public Const AdminServiceInfoEdit As String = "/Administrator/DictIndex/AdminServiceInfoEdit.aspx"
            Public Const AdminDepartmentList As String = "/Administrator/DictIndex/AdminDepartmentList.aspx"
            Public Const AdminDepartmentEdit As String = "/Administrator/DictIndex/AdminDepartmentEdit.aspx"
            Public Const AdminCooperateModelList As String = "/Administrator/DictIndex/AdminCooperateModelList.aspx"
            Public Const AdminCooperateModelEdit As String = "/Administrator/DictIndex/AdminCooperateModelEdit.aspx"
            Public Const AdminConfidenceList As String = "/Administrator/DictIndex/AdminConfidenceList.aspx"
            Public Const AdminConfidenceEdit As String = "/Administrator/DictIndex/AdminConfidenceEdit.aspx"
            Public Const AdminStaffInternalList As String = "/Administrator/DictIndex/AdminStaffInternalList.aspx"
            Public Const AdminStaffInternalEdit As String = "/Administrator/DictIndex/AdminStaffInternalEdit.aspx"
            Public Const AdminUsersList As String = "/Administrator/Users/AdminUsersList.aspx"
            Public Const AdminUsersEdit As String = "/Administrator/Users/AdminUsersEdit.aspx"

        End Class
#End Region
#Region "Android Apps"
        Public Class _AndroidApps
            Public Const AndroidAppsDictIndexList As String = "/AndroidApps/DictIndex/AndroidAppsDictIndexList.aspx"
            Public Const AndroidAppsDictIndexEdit As String = "/AndroidApps/DictIndex/AndroidAppsDictIndexEdit.aspx"
            Public Const AndroidAppsDictIndexKwBlackList As String = "/AndroidApps/DictIndex/AndroidAppsDictIndexKwBlackList.aspx"
            Public Const AndroidAppsDictIndexKwBlackEdit As String = "/AndroidApps/DictIndex/AndroidAppsDictIndexKwBlackEdit.aspx"
        End Class
#End Region
#Region "Ccare B2C"
        Public Class _CcareB2C
            Public Const CcareDictIndexSourceList As String = "/CustomerInfo/DictIndex/CcareDictIndexSourceList.aspx"
            Public Const CcareDictIndexSourceEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexSourceEdit.aspx"
            Public Const CcareDictIndexPartnerList As String = "/CustomerInfo/DictIndex/CcareDictIndexPartnerList.aspx"
            Public Const CcareDictIndexPartnerEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexPartnerEdit.aspx"
            Public Const CcareDictIndexFieldList As String = "/CustomerInfo/DictIndex/CcareDictIndexFieldList.aspx"
            Public Const CcareDictIndexFieldEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexFieldEdit.aspx"
            Public Const CcareDictIndexFeesList As String = "/CustomerInfo/DictIndex/CcareDictIndexFeesList.aspx"
            Public Const CcareDictIndexFeesEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexFeesEdit.aspx"
            Public Const CcareDictIndexInComeList As String = "/CustomerInfo/DictIndex/CcareDictIndexInComeList.aspx"
            Public Const CcareDictIndexInComeEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexInComeEdit.aspx"
            Public Const CcareDictIndexRefuseList As String = "/CustomerInfo/DictIndex/CcareDictIndexRefuseList.aspx"
            Public Const CcareDictIndexRefuseEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexRefuseEdit.aspx"
            Public Const CcareDictIndexProvinceList As String = "/CustomerInfo/DictIndex/CcareDictIndexProvinceList.aspx"
            Public Const CcareDictIndexProvinceEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexProvinceEdit.aspx"
            Public Const CcareDictIndexDistrictList As String = "/CustomerInfo/DictIndex/CcareDictIndexDistrictList.aspx"
            Public Const CcareDictIndexDistrictEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexDistrictEdit.aspx"
            Public Const CcareDictIndexBrandList As String = "/CustomerInfo/DictIndex/CcareDictIndexBrandList.aspx"
            Public Const CcareDictIndexBrandEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexBrandEdit.aspx"
            Public Const CCareCustomerInfoList As String = "/CustomerInfo/DataInfo/CCareCustomerInfoList.aspx"
            Public Const CCareCustomerInfoEdit As String = "/CustomerInfo/DataInfo/CCareCustomerInfoEdit.aspx"
            Public Const CCareImportUser As String = "/CustomerInfo/DataInfo/CCareImportUser.aspx"
            Public Const CCareVerifyUser1 As String = "/CustomerInfo/DataInfo/CCareVerifyUser1.aspx"
            Public Const CCareVerifyUser1List As String = "/CustomerInfo/DataInfo/CCareVerifyUser1List.aspx"
            Public Const CCareVerifyUser2 As String = "/CustomerInfo/DataInfo/CCareVerifyUser2.aspx"
            Public Const CcareDictIndexCareerList As String = "/CustomerInfo/DictIndex/CcareDictIndexCareerList.aspx"
            Public Const CcareDictIndexCareerEdit As String = "/CustomerInfo/DictIndex/CcareDictIndexCareerEdit.aspx"
        End Class
#End Region
#Region "SMS"
        Public Class _SMS
            Public Const SMSDictIndexKeywordList As String = "/SMS/DictIndex/SMSDictIndexKeywordList.aspx"
            Public Const SMSDictIndexKeywordEdit As String = "/SMS/DictIndex/SMSDictIndexKeywordEdit.aspx"
            Public Const SMSDictIndexServiceEdit As String = "/SMS/DictIndex/SMSDictIndexServiceEdit.aspx"
            Public Const SMSDictIndexServiceList As String = "/SMS/DictIndex/SMSDictIndexServiceList.aspx"
            Public Const SMSDictIndexLotteryCompanyList As String = "/SMS/DictIndex/SMSDictIndexLotteryCompanyList.aspx"
            Public Const SMSDictIndexLotteryCompanyEdit As String = "/SMS/DictIndex/SMSDictIndexLotteryCompanyEdit.aspx"
            Public Const SMSDictIndexKeywordFilterList As String = "/SMS/DictIndex/SMSDictIndexKeywordFilterList.aspx"
            Public Const SMSDictIndexKeywordFilterEdit As String = "/SMS/DictIndex/SMSDictIndexKeywordFilterEdit.aspx"
            Public Const SMSDictIndexKeywordDeclareList As String = "/SMS/DictIndex/SMSDictIndexKeywordDeclareList.aspx"
            Public Const SMSDictIndexKeywordDeclareEdit As String = "/SMS/DictIndex/SMSDictIndexKeywordDeclareEdit.aspx"
            Public Const SMSDictIndexKeywordMgrList As String = "/SMS/DictIndex/SMSDictIndexKeywordMgrList.aspx"
            Public Const SMSDictIndexKeywordMgrEdit As String = "/SMS/DictIndex/SMSDictIndexKeywordMgrEdit.aspx"
        End Class
#End Region
#Region "S2"
        Public Class _S2
            Public Const S2DictIndexVMSServiceList As String = "/SubscriptionService/DictIndex/S2DictIndexVMSServiceList.aspx"
            Public Const S2DictIndexVMSServiceEdit As String = "/SubscriptionService/DictIndex/S2DictIndexVMSServiceEdit.aspx"
            Public Const S2DictIndexVNPServiceList As String = "/SubscriptionService/DictIndex/S2DictIndexVNPServiceList.aspx"
            Public Const S2DictIndexVNPServiceEdit As String = "/SubscriptionService/DictIndex/S2DictIndexVNPServiceEdit.aspx"
            Public Const S2DictIndexVNMServiceList As String = "/SubscriptionService/DictIndex/S2DictIndexVNMServiceList.aspx"
            Public Const S2DictIndexVNMServiceEdit As String = "/SubscriptionService/DictIndex/S2DictIndexVNMServiceEdit.aspx"
        End Class
#End Region
#Region "Charging"
        Public Class _Charging
            Public Const ChargingDictIndexUrlList As String = "/Charging/DictIndex/ChargingDictIndexUrlList.aspx"
            Public Const ChargingDictIndexUrlEdit As String = "/Charging/DictIndex/ChargingDictIndexUrlEdit.aspx"
        End Class
#End Region
#Region "Vishare"
        Public Class _Vishare
            Public Const VishareDictIndexUrlList As String = "/Vishare/DictIndex/VishareDictIndexUrlList.aspx"
            Public Const VishareDictIndexUrlEdit As String = "/Vishare/DictIndex/VishareDictIndexUrlEdit.aspx"
        End Class
#End Region

#Region "VMGame"
        Public Class _GamePortal
            Public Const VMGameDictIndexServiceList As String = "/GamePortal/DictIndex/VMGameDictIndexServiceList.aspx"
            Public Const VMGameDictIndexServiceEdit As String = "/GamePortal/DictIndex/VMGameDictIndexServiceEdit.aspx"
            Public Const GamePortalDictIndexServiceList As String = "/GamePortal/DictIndex/GamePortalDictIndexServiceList.aspx"
            Public Const GamePortalDictIndexServiceEdit As String = "/GamePortal/DictIndex/GamePortalDictIndexServiceEdit.aspx"
        End Class
#End Region
#Region "Sim Tool Kit"
        Public Class _STK
            Public Const STKDictIndexServiceList As String = "/SimToolKit/DictIndex/STKDictIndexServiceList.aspx"
            Public Const STKDictIndexServiceEdit As String = "/SimToolKit/DictIndex/STKDictIndexServiceEdit.aspx"

        End Class
#End Region
#Region "Billing"
        Public Class _Billing
            Public Const BilBrandDictIndexTaskList As String = "/Billing/DictIndex/BilBrandDictIndexTaskList.aspx"
            Public Const BilBrandDictIndexTaskEdit As String = "/Billing/DictIndex/BilBrandDictIndexTaskEdit.aspx"
            Public Const BilBrandWorkFollowList As String = "/Billing/Brand/BilBrandWorkFollowList.aspx"
            Public Const BilBrandWorkFollowEdit As String = "/Billing/Brand/BilBrandWorkFollowEdit.aspx"
            Public Const BilBrandInitDataList As String = "/Billing/Brand/BilBrandInitDataList.aspx"
            Public Const BilBrandInitDataEdit As String = "/Billing/Brand/BilBrandInitDataEdit.aspx"

            Public Const BilSMSDictIndexTaskList As String = "/Billing/DictIndex/BilSMSDictIndexTaskList.aspx"
            Public Const BilSMSDictIndexTaskEdit As String = "/Billing/DictIndex/BilSMSDictIndexTaskEdit.aspx"
            Public Const BilSMSInitDataList As String = "/Billing/SMSMO/BilSMSInitDataList.aspx"
            Public Const BilSMSInitDataEdit As String = "/Billing/SMSMO/BilSMSInitDataEdit.aspx"
            Public Const BilSMSWorkFollowList As String = "/Billing/SMSMO/BilSMSWorkFollowList.aspx"
            Public Const BilSMSWorkFollowEdit As String = "/Billing/SMSMO/BilSMSWorkFollowEdit.aspx"

            Public Const BilScratchCardDictIndexTaskList As String = "/Billing/DictIndex/BilScratchCardDictIndexTaskList.aspx"
            Public Const BilScratchCardDictIndexTaskEdit As String = "/Billing/DictIndex/BilScratchCardDictIndexTaskEdit.aspx"
            Public Const BilScratchCardInitDataList As String = "/Billing/ScratchCard/BilScratchCardInitDataList.aspx"
            Public Const BilScratchCardInitDataEdit As String = "/Billing/ScratchCard/BilScratchCardInitDataEdit.aspx"
            Public Const BilScratchCardWorkFollowEdit As String = "/Billing/ScratchCard/BilScratchCardWorkFollowEdit.aspx"
            Public Const BilScratchCardWorkFollowList As String = "/Billing/ScratchCard/BilScratchCardWorkFollowList.aspx"
            Public Const BilScratchCardRatioLossList As String = "/Billing/ScratchCard/BilScratchCardRatioLossList.aspx"
            Public Const BilScratchCardRatioLossEdit As String = "/Billing/ScratchCard/BilScratchCardRatioLossEdit.aspx"

            Public Const BilS2DictIndexTaskList As String = "/Billing/DictIndex/BilS2DictIndexTaskList.aspx"
            Public Const BilS2DictIndexTaskEdit As String = "/Billing/DictIndex/BilS2DictIndexTaskEdit.aspx"
            Public Const BilS2InitDataList As String = "/Billing/S2/BilS2InitDataList.aspx"
            Public Const BilS2InitDataEdit As String = "/Billing/S2/BilS2InitDataEdit.aspx"
            Public Const BilS2WorkFollowEdit As String = "/Billing/S2/BilS2WorkFollowEdit.aspx"
            Public Const BilS2WorkFollowList As String = "/Billing/S2/BilS2WorkFollowList.aspx"
        End Class
#End Region
#Region "M-Game"
        Public Class _MGame
            Public Const MGameDictIndexUrlList As String = "/MGame/DictIndex/MGameDictIndexUrlList.aspx"
            Public Const MGameDictIndexUrlEdit As String = "/MGame/DictIndex/MGameDictIndexUrlEdit.aspx"
        End Class
#End Region
#Region "Pregnancy Diary"
        Public Class _PregnancyDiary
            Public Const PreDiaryDictIndexUrlList As String = "/SubscriptionService/Report/VNP/PregnancyDiary/PreDiaryDictIndexUrlList.aspx"
            Public Const PreDiaryDictIndexUrlEdit As String = "/SubscriptionService/Report/VNP/PregnancyDiary/PreDiaryDictIndexUrlEdit.aspx"
        End Class
#End Region
#Region "KPI"
        Public Class _KPI
            Public Const KpiLotDictIndexInputDataList As String = "/KPI/DictIndex/KpiLotDictIndexInputDataList.aspx"
            Public Const KpiLotDictIndexInputDataEdit As String = "/KPI/DictIndex/KpiLotDictIndexInputDataEdit.aspx"
            Public Const KpiLotDictIndexInputLuckyNumberList As String = "/KPI/DictIndex/KpiLotDictIndexInputLuckyNumberList.aspx"
            Public Const KpiLotDictIndexInputLuckyNumberEdit As String = "/KPI/DictIndex/KpiLotDictIndexInputLuckyNumberEdit.aspx"
            Public Const KpiLotDictIndexInputDataErrorList As String = "/KPI/DictIndex/KpiLotDictIndexInputDataErrorList.aspx"
            Public Const KpiLotDictIndexInputDataErrorEdit As String = "/KPI/DictIndex/KpiLotDictIndexInputDataErrorEdit.aspx"
            Public Const KpiLotDictIndexInputSoftwareErrorList As String = "/KPI/DictIndex/KpiLotDictIndexInputSoftwareErrorList.aspx"
            Public Const KpiLotDictIndexInputSoftwareErrorEdit As String = "/KPI/DictIndex/KpiLotDictIndexInputSoftwareErrorEdit.aspx"
            Public Const KpiLotDictIndexTechnicalQualityMTList As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualityMTList.aspx"
            Public Const KpiLotDictIndexTechnicalQualityMTEdit As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualityMTEdit.aspx"
            Public Const KpiLotDictIndexTechnicalQualityHandleList As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualityHandleList.aspx"
            Public Const KpiLotDictIndexTechnicalQualityHandleEdit As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualityHandleEdit.aspx"
            Public Const KpiLotDictIndexTechnicalQualityOperatorList As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualityOperatorList.aspx"
            Public Const KpiLotDictIndexTechnicalQualityOperatorEdit As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualityOperatorEdit.aspx"
            Public Const KpiLotDictIndexTechnicalQualitySystemErrList As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualitySystemErrList.aspx"
            Public Const KpiLotDictIndexTechnicalQualitySystemErrEdit As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualitySystemErrEdit.aspx"
            Public Const KpiLotDictIndexTechnicalQualityMTErrList As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualityMTErrList.aspx"
            Public Const KpiLotDictIndexTechnicalQualityMTErrEdit As String = "/KPI/DictIndex/KpiLotDictIndexTechnicalQualityMTErrEdit.aspx"
            Public Class Brand
                Public Const KpiBrDictIndexTimeUpAdvList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexTimeUpAdvList.aspx"
                Public Const KpiBrDictIndexTimeUpAdvEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexTimeUpAdvEdit.aspx"
                Public Const KpiBrDictIndexTimeApproveBrandCcareList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexTimeApproveBrandCcareList.aspx"
                Public Const KpiBrDictIndexTimeApproveBrandCcareEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexTimeApproveBrandCcareEdit.aspx"
                Public Const KpiBrDictIndexInputDataErrList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexInputDataErrList.aspx"
                Public Const KpiBrDictIndexInputDataErrEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexInputDataErrEdit.aspx"
                Public Const KpiBrDictIndexMTErrorNoChargeList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexMTErrorNoChargeList.aspx"
                Public Const KpiBrDictIndexMTErrorNoChargeEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexMTErrorNoChargeEdit.aspx"
                Public Const KpiBrDictIndexInputSoftwareErrorList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexInputSoftwareErrorList.aspx"
                Public Const KpiBrDictIndexInputSoftwareErrorEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexInputSoftwareErrorEdit.aspx"
                Public Const KpiBrDictIndexTechnicalQualityMTList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexTechnicalQualityMTList.aspx"
                Public Const KpiBrDictIndexTechnicalQualityMTEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexTechnicalQualityMTEdit.aspx"
                Public Const KpiBrDictIndexTechnicalQualitySystemErrList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexTechnicalQualitySystemErrList.aspx"
                Public Const KpiBrDictIndexTechnicalQualitySystemErrEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexTechnicalQualitySystemErrEdit.aspx"
                Public Const KpiBrDictIndexCcareList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexCcareList.aspx"
                Public Const KpiBrDictIndexCcareEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexCcareEdit.aspx"
                Public Const KpiBrDictIndexRoutingList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexRoutingList.aspx"
                Public Const KpiBrDictIndexRoutingEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexRoutingEdit.aspx"
                Public Const KpiBrDictIndexQualityReportList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexQualityReportList.aspx"
                Public Const KpiBrDictIndexQualityReportEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexQualityReportEdit.aspx"
                Public Const KpiBrDictIndexQualityCheckingList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexQualityCheckingList.aspx"
                Public Const KpiBrDictIndexQualityCheckingEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexQualityCheckingEdit.aspx"
                Public Const KpiBrDictIndexQualityPaymentList As String = "/KPI/DictIndex/Brand/KpiBrDictIndexQualityPaymentList.aspx"
                Public Const KpiBrDictIndexQualityPaymentEdit As String = "/KPI/DictIndex/Brand/KpiBrDictIndexQualityPaymentEdit.aspx"
            End Class
            Public Class ScratchCard
                Public Const KpiScratchCardDictIndexTechnicalQualitySystemErrList As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexTechnicalQualitySystemErrList.aspx"
                Public Const KpiScratchCardDictIndexTechnicalQualitySystemErrEdit As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexTechnicalQualitySystemErrEdit.aspx"
                Public Const KpiScratchCardDictIndexTransactionTimeList As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexTransactionTimeList.aspx"
                Public Const KpiScratchCardDictIndexTransactionTimeEdit As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexTransactionTimeEdit.aspx"
                Public Const KpiScratchCardDictIndexTransactionPendingList As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexTransactionPendingList.aspx"
                Public Const KpiScratchCardDictIndexTransactionPendingEdit As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexTransactionPendingEdit.aspx"
                Public Const KpiScratchCardDictIndexCheckingDataList As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexCheckingDataList.aspx"
                Public Const KpiScratchCardDictIndexCheckingDataEdit As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexCheckingDataEdit.aspx"
                Public Const KpiScratchCardDictIndexPaymentList As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexPaymentList.aspx"
                Public Const KpiScratchCardDictIndexPaymentEdit As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexPaymentEdit.aspx"
                Public Const KpiScratchCardDictIndexOutBillList As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexOutBillList.aspx"
                Public Const KpiScratchCardDictIndexOutBillEdit As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexOutBillEdit.aspx"
                Public Const KpiScratchCardDictIndexCcareList As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexCcareList.aspx"
                Public Const KpiScratchCardDictIndexCcareEdit As String = "/KPI/DictIndex/ScratchCard/KpiScratchCardDictIndexCcareEdit.aspx"
            End Class
            Public Class Infras
                Public Const KpiInfrasDictIndexTechnicalQualitySysDownTimeList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexTechnicalQualitySysDownTimeList.aspx"
                Public Const KpiInfrasDictIndexTechnicalQualitySysDownTimeEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexTechnicalQualitySysDownTimeEdit.aspx"
                Public Const KpiInfrasDictIndexTechnicalQualityServerErrList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexTechnicalQualityServerErrList.aspx"
                Public Const KpiInfrasDictIndexTechnicalQualityServerErrEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexTechnicalQualityServerErrEdit.aspx"
                Public Const KpiInfrasDictIndexTechnicalQualitySrvPerformanceList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexTechnicalQualitySrvPerformanceList.aspx"
                Public Const KpiInfrasDictIndexTechnicalQualitySrvPerformanceEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexTechnicalQualitySrvPerformanceEdit.aspx"
                Public Const KpiInfrasDictIndexInternetBandwidthList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexInternetBandwidthList.aspx"
                Public Const KpiInfrasDictIndexInternetBandwidthEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexInternetBandwidthEdit.aspx"
                Public Const KpiInfrasDictIndexLeaseLineBandwidthList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexLeaseLineBandwidthList.aspx"
                Public Const KpiInfrasDictIndexLeaseLineBandwidthEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexLeaseLineBandwidthEdit.aspx"
                Public Const KpiInfrasDictIndexServiceMobileOperatorList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexServiceMobileOperatorList.aspx"
                Public Const KpiInfrasDictIndexServiceMobileOperatorEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexServiceMobileOperatorEdit.aspx"
                Public Const KpiInfrasDictIndexStabilityOfInternetList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexStabilityOfInternetList.aspx"
                Public Const KpiInfrasDictIndexStabilityOfInternetEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexStabilityOfInternetEdit.aspx"
                Public Const KpiInfrasDictIndexStabilityOfLeaseLineList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexStabilityOfLeaseLineList.aspx"
                Public Const KpiInfrasDictIndexStabilityOfLeaseLineEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexStabilityOfLeaseLineEdit.aspx"
                Public Const KpiInfrasDictIndexCapacityOfSysList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexCapacityOfSysList.aspx"
                Public Const KpiInfrasDictIndexCapacityOfSysEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexCapacityOfSysEdit.aspx"
                Public Const KpiInfrasDictIndexIntegrityDataList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexIntegrityDataList.aspx"
                Public Const KpiInfrasDictIndexIntegrityDataEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexIntegrityDataEdit.aspx"
                Public Const KpiInfrasDictIndexDataCenterList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexDataCenterList.aspx"
                Public Const KpiInfrasDictIndexDataCenterEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexDataCenterEdit.aspx"
                Public Const KpiInfrasDictIndexSecurityList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexSecurityList.aspx"
                Public Const KpiInfrasDictIndexSecurityEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexSecurityEdit.aspx"
                Public Const KpiInfrasDictIndexAlertList As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexAlertList.aspx"
                Public Const KpiInfrasDictIndexAlertEdit As String = "/KPI/DictIndex/Infras/KpiInfrasDictIndexAlertEdit.aspx"
            End Class
        End Class
#End Region
    End Class
#End Region
#Region "LKF"
#Region "Lottery Company"
    Public Class Company
        Public Class CompanyId
            Public Const _CaMau As Integer = 1
            Public Const _DongThap As Integer = 2
            Public Const _AnGiang As Integer = 3
            Public Const _BinhDuong As Integer = 4
            Public Const _BacLieu As Integer = 5
            Public Const _BinhPhuoc As Integer = 6
            Public Const _BenTre As Integer = 7
            Public Const _BinhThuan As Integer = 8
            Public Const _CanTho As Integer = 9
            Public Const _DongNai As Integer = 10
            Public Const _HCM As Integer = 11
            Public Const _HauGiang As Integer = 12
            Public Const _KienGiang As Integer = 13
            Public Const _LamDong As Integer = 14
            Public Const _LongAn As Integer = 15
            Public Const _SocTrang As Integer = 16
            Public Const _TienGiang As Integer = 17
            Public Const _TayNinh As Integer = 18
            Public Const _TraVinh As Integer = 19
            Public Const _VinhLong As Integer = 20
            Public Const _VungTau As Integer = 21
            Public Const _BinhDinh As Integer = 22
            Public Const _DakLak As Integer = 23
            Public Const _DakNong As Integer = 24
            Public Const _DaNang As Integer = 25
            Public Const _GiaLai As Integer = 26
            Public Const _NinhThuan As Integer = 27
            Public Const _KhanhHoa As Integer = 28
            Public Const _KonTum As Integer = 29
            Public Const _PhuYen As Integer = 30
            Public Const _QuangBinh As Integer = 31
            Public Const _QuangNgai As Integer = 32
            Public Const _QuangNam As Integer = 33
            Public Const _QuangTri As Integer = 34
            Public Const _Hue As Integer = 35
            Public Const _MienBacKhac As Integer = 36
            Public Const _MienNam As Integer = 37
            Public Const _MienTrung As Integer = 38
            Public Const _MienBac As Integer = 39
            Public Const _ThuDo As Integer = 40

        End Class
        Public Class CompanyText
            Public Const _CaMau As String = "CaMau"
            Public Const _DongThap As String = "DongThap"
            Public Const _AnGiang As String = "AnGiang"
            Public Const _BinhDuong As String = "BinhDuong"
            Public Const _BacLieu As String = "BacLieu"
            Public Const _BinhPhuoc As String = "BinhPhuoc"
            Public Const _BenTre As String = "BenTre"
            Public Const _BinhThuan As String = "BinhThuan"
            Public Const _CanTho As String = "CanTho"
            Public Const _DongNai As String = "DongNai"
            Public Const _HCM As String = "HCM"
            Public Const _HauGiang As String = "HauGiang"
            Public Const _KienGiang As String = "KienGiang"
            Public Const _LamDong As String = "LamDong"
            Public Const _LongAn As String = "LongAn"
            Public Const _SocTrang As String = "SocTrang"
            Public Const _TienGiang As String = "TienGiang"
            Public Const _TayNinh As String = "TayNinh"
            Public Const _TraVinh As String = "TraVinh"
            Public Const _VinhLong As String = "VinhLong"
            Public Const _VungTau As String = "VungTau"
            Public Const _BinhDinh As String = "BinhDinh"
            Public Const _DakLak As String = "DakLak"
            Public Const _DakNong As String = "DakNong"
            Public Const _DaNang As String = "DaNang"
            Public Const _GiaLai As String = "GiaLai"
            Public Const _NinhThuan As String = "NinhThuan"
            Public Const _KhanhHoa As String = "KhanhHoa"
            Public Const _KonTum As String = "KonTum"
            Public Const _PhuYen As String = "PhuYen"
            Public Const _QuangBinh As String = "QuangBinh"
            Public Const _QuangNgai As String = "QuangNgai"
            Public Const _QuangNam As String = "QuangNam"
            Public Const _QuangTri As String = "QuangTri"
            Public Const _Hue As String = "Hue"
            Public Const _MienBacKhac As String = "MienBacKhac"
            Public Const _MienNam As String = "MienNam"
            Public Const _MienTrung As String = "MienTrung"
            Public Const _MienBac As String = "MienBac"
            Public Const _ThuDo As String = "ThuDo"

        End Class
    End Class
#End Region
#End Region
#Region "Channel Game"
    Public Class Game
        Public Class GameId
            Public Const _CS_1 As String = "100035"
            Public Const _Bleach_1 As String = "100047"
            Public Const _Bleach_2 As String = "100042"
            Public Const _Bleach_3 As String = "100052"
            Public Const _TCQ_1 As String = "100036"
            Public Const _TCQ_2 As String = "100053"
            Public Const _PT_1 As String = "100049"
            Public Const _PT_2 As String = "100051"
            Public Const _PT_3 As String = "100043"
            Public Const _Others_1 As String = "100009"
            Public Const _Others_2 As String = "100019"
            Public Const _Others_3 As String = "100041"
            Public Const _Others_4 As String = "100050"
        End Class
        Public Class GameText
            Public Const _CS As String = "CS Mobile"
            Public Const _Bleach As String = "Bleach"
            Public Const _TCQ As String = "Trà Chanh Quán "
            Public Const _PT As String = "Phong Thần"
            Public Const _Others As String = "Các game khác"
        End Class
        Public Class PaymentTypeId
            Public Const _SMS As Integer = 1
            Public Const _Scratch_Card As Integer = 2
            Public Const _Banking As Integer = 3
        End Class
        Public Class PaymentTypeText
            Public Const _SMS As String = "SMS"
            Public Const _Scratch_Card As String = "Thẻ cào"
            Public Const _Banking As String = "Ngân hàng"
        End Class
    End Class
#End Region
#Region "Declare Keyword"
    Public Class DeclareKeyword
        Public Class StatusId
            Public Const Create_New As Integer = 1
            Public Const Request_Routing As Integer = 2
            Public Const Declare_Routing As Integer = 3
            Public Const Declare_Telcos As Integer = 4
            Public Const Telcos_Approved As Integer = 5
            Public Const Telcos_Reject As Integer = 6
            'Public Const Telcos_Reject_Edit As Integer = 6
            'Public Const Telcos_Reject_Cancel As Integer = 7
            Public Const Declare_Report As Integer = 8
            Public Const Add_Partner As Integer = 9
            Public Const Closed As Integer = 10
        End Class
        Public Class StatusText
            Public Const Create_New As String = "Tạo mới"
            Public Const Request_Routing As String = "Y/c định tuyến"
            Public Const Declare_Routing As String = "Khai báo định tuyến"
            Public Const Declare_Telcos As String = "Khai báo Telcos"
            Public Const Telcos_Approved As String = "Telcos duyệt"
            Public Const Telcos_Reject As String = "Telcos từ chối"
            'Public Const Telcos_Reject_Edit As String = "Telcos từ chối, sửa"
            'Public Const Telcos_Reject_Cancel As String = "Telcos từ chối, hủy"
            Public Const Declare_Report As String = "Khai báo Report, Filter"
            Public Const Add_Partner As String = "Gán doanh thu"
            Public Const Closed As String = "Đóng"
        End Class
    End Class
#End Region
#Region "CultureInfo"
    Public Class CultureInfo
        Public Const culture_Fr As String = "fr-FR"
        Public Const culture_En As String = "en-US"

    End Class
#End Region

End Class

