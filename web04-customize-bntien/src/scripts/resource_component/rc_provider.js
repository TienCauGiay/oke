const PROVIDER = {
    title: "Danh sách nhà cung cấp",
    overdue: "Nợ quá hạn",
    totalLiabiliti: "Tổng nợ phải trả",
    recentPayment: "Đã thanh toán (30 ngày gần đây)",
    figureUpto: "Số liệu tính đến: 6h09",
    placeholderSearch: "Tìm kiếm",   
    colTableName: {
        providerCode: "Mã nhà cung cấp",
        providerName: "Tên nhà cung cấp",
        address: "Địa chỉ",
        amountOwed: "Số tiền nợ",
        rawCode: "Mã số thuế",
        phoneNumber: "Điện thoại",
        branch: "Chi nhánh",
    },
    confirmDelete: {
        prev: "Bạn có thực sự muốn xóa nhà cung cấp <",
        end: "> không?",
        multiple: "Bạn có thực sự muốn xóa những nhà cung cấp đã chọn không?",
    },
    valueState:{
        usingAccount: "Đang sử dụng",
        stopUsingAccount: "Ngưng sử dụng"
    } ,
    form: {
        textProperty:{
            taxCode: "Mã số thuế",
            providerCode: "Mã nhà cung cấp",
        },
        validateNotNull: {
            "ProviderCode": "Mã nhà cung cấp không được để trống.",
            "ProviderName": "Tên nhà cung cấp không được để trống.",
        },
        maxLength: {
            "ProviderCode": {Limit: 20, Warning : "Mã nhà cung cấp tối đa 20 kí tự."},
            "ProviderName": {Limit: 255, Warning : "Tên nhà cung cấp tối đa 255 kí tự."},
            "TaxCode": {Limit: 20, Warning : "Mã số thuế tối đa 20 kí tự."},
            "Address": {Limit: 255, Warning : "Địa chỉ tối đa 255 kí tự."},
            "PhoneNumber": {Limit: 50, Warning : "Số điện thoại tối đa 50 kí tự."},
            "Website": {Limit: 255, Warning : "Website tối đa 255 kí tự"},
            "Note": {Limit: 10000, Warning : "Chú ý tối đa 10000 kí tự"},
        },
    }
}

export default PROVIDER;