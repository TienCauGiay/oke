const MISAEnum = {
    STATUS:{
        // API đã xử lý yêu cầu thành công và trả về kết quả
        OK: 200,

        // Một tài nguyên mới đã được tạo thành công
        CREATED: 201,

        // Yêu cầu không hợp lệ
        BAD_REQUEST: 400,

        // Không có quyền truy cập vào tài nguyên hoặc không có thông tin chứng thực
        UNAUTHORIZED: 401,

        // Tài nguyên yêu cầu không được tìm thấy trên máy chủ
        NOT_FOUND: 404,

        // Xảy ra lỗi nội bộ trên máy chủ khi xử lí yêu cầu và không thể hoàn thành nó
        INTERNAL_SERVER_ERROR: 500
    },

    CHECK_STATUS:{
        // Kiểm tra trạng thái có phải 200 không
        isResponseStatusOk: (status) => {
            return status === 200;
        },

        // Kiểm tra trạng thái có phải 201 không
        isResponseStatusCreated: (status) => {
            return status === 201;
        },

        // Kiểm tra trạng thái có phải 400 không
        isResponseStatusBadRequest: (status) => {
            return status === 400;
        },

        // Kiểm tra trạng thái có phải 401 không
        isResponseStatusUnauthorized: (status) => {
            return status === 401;
        },

        // Kiểm tra trạng thái có phải 404 không
        isResponseStatusNotFound: (status) => {
            return status === 404;
        },

        // Kiểm tra trạng thái có phải 500 không
        isResponseStatusServerError: (status) => {
            return status === 500;
        }
    },

    RECORD:{
        CURRENT_PAGE: 1,
        MAX_VISIBLE_PAGE: 3,
        RECORD_DEFAULT : 20,
        RECORD_OPTIONS : [10, 20, 30, 50, 100],
        INDEX_SELECTED_DEFAULT: 1,
    },

    GENDER:{
        Male: 0,
        Female: 1,
        Other: 2
    },

    FORM_MODE: {
        Add: 1,
        Edit: 2
    },
    KEY_CODE:{
        DOWN: 40,
        UP: 38,
        ENTER: 13
    },
    CUSTOMER: 1,
    PROVIDER: 1,

    BOOL: {
        TRUE: 1,
        FALSE: 0
    }
} 

export default MISAEnum;
