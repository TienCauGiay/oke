const helperCommon = {
  /**
   * Mô tả: Hàm xử lí chuỗi thành định dạng ngày tháng năm (dd/MM/yyyy)
   * created by : BNTIEN
   * created date: 04-06-2023 19:13:03
   */
    formatDate: (value) => {
        try {
          value = value.substring(0, 10);
          const dates = value.split("-");
          const res = `${dates[2]}/${dates[1]}/${dates[0]}`;
          return res;
        } catch (error) {
          return "";
        }
    },
    /**
     * Mô tả: Hàm xóa dấu tiếng việt
     * created by : BNTIEN
     * created date: 04-06-2023 19:13:39
     */
    removeVietnameseAccents: (str) => {
      return str
        .normalize("NFD")
        .replace(/[\u0300-\u036f]/g, "")
        .replace(/đ/g, "d")
        .replace(/Đ/g, "D");
    },
    /**
     * Mô tả: Hàm kiểm tra ngày hợp lệ
     * created by : BNTIEN
     * created date: 08-06-2023 03:22:05
     */
    isInvalidDate: (value) => {
      const dob = new Date(value);      
      const dateToday = new Date();
      if(dob > dateToday){
        return true;
      }
      else{
        return false;
      }
    },
    /**
     * Mô tả: Hàm xử lí lỗi nhập liệu của thực thể khi input, update
     * created by : BNTIEN
     * created date: 04-07-2023 14:43:43
     */
    handleErrorInput: (errors, objectProperty) => {
      const dataNotNull = [];
      const isBorderRed = {};
      for (const key of objectProperty) {
        if (key in errors) {
          dataNotNull.push(errors[key]);
          isBorderRed[key] = true;
        }
      }
      return {
        'error': errors,
        'dataNotNull': dataNotNull,
        'isBorderRed': isBorderRed
      }
    },
    /**
     * Mô tả: Hàm kiểm tra dữ liệu rỗng
     * created by : BNTIEN
     * created date: 11-07-2023 13:29:51
     */
    isEmptyInput: (text) =>{
      if(!text){
        return true;
      }
      return false;
    },
    /**
     * Mô tả: Hàm kiểm tra dữ liệu vượt quá số kí tự cho phép
     * created by : BNTIEN
     * created date: 11-07-2023 14:01:11
     */
    isMaxLengthInput: (text, length) => {
      if(!text) return false;
      if(text.length > length){
        return true;
      }
      return false;
    },


    /**
     * Mô tả: Hàm kiểm tra dữ liệu tối thiểu là bao nhiêu
     * created by : BNTIEN
     * created date: 23-07-2023 12:10:12
     */
    isMinLengthInput: (text, length) => {
      if(!text) return false;
      if(text.length < length){
        return true;
      }
      return false;
    },

    /**
     * Mô tả: Hàm kiểm tra định dạng email 
     * created by : BNTIEN
     * created date: 11-07-2023 16:26:14
     */
    isFormatEmail: (text) => {
      if(!text) return false;
      const regex = /^\S+@\S+\.\S+$/;
      if(!regex.test(text)){
        return true;
      }
      return false;
    },

    /**
     * Mô tả: Hàm kiểm tra chuỗi có phải toàn số không
     * created by : BNTIEN
     * created date: 16-07-2023 14:45:44
     */
    isNumber: (text) => {
      if(!text) return false;
      const regex = /^[0-9]+$/;
      if(!regex.test(text)){
        return true;
      }
      return false;
    },
}

export default helperCommon;