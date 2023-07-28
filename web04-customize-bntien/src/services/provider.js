import BaseServices from "./base";

class ProviderService extends BaseServices {
    controller = "Providers";

    /**
     * Mô tả: Lấy mã nhà cung cấp lớn nhất trong hệ thống
     * created by : BNTIEN
     * created date: 28-07-2023 06:28:12
     */
    async getCodeMax(){
        var response = await this.entity.get(`${this.getBaseUrl()}/maxcode`);
        return response;
    }

    
}

export default new ProviderService();