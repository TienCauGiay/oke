<template>
  <div
    id="detail-add-system-account"
    class="position-display-right"
    ref="FormDetailSystemAccount"
  >
    <div class="form-detail-toolbar">
      <div
        class="question-icon icon-tb"
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.HELP"
      ></div>
      <div
        @click="onCloseFormDetail"
        class="close-icon icon-tb"
        id="system-account-exit"
        @keydown.tab.prevent="resetTab($event.target.value)"
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.EXIST"
      ></div>
    </div>
    <div class="form-detail-main">
      <div class="system-account-title">
        <p>
          <b>{{ this.titleFormMode }}</b>
        </p>
      </div>
      <div class="form-detail-content">
        <div class="full-content">
          <div class="col-md-quater">
            <label>
              {{
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .accountNumber
              }}
              <span class="s-require">*</span>
            </label>
            <div class="container-input">
              <misa-input
                ref="AccountNumber"
                v-model="account.AccountNumber"
                :class="{ 'border-red': isBorderRed.AccountNumber }"
                @input="setIsBorderRed('AccountNumber')"
                @mouseenter="isHovering.AccountNumber = true"
                @mouseleave="isHovering.AccountNumber = false"
              ></misa-input>
              <div
                class="misa-tooltip"
                v-if="
                  isHovering.AccountNumber &&
                  (isBorderRed.AccountNumber || !account.AccountNumber) &&
                  errors['AccountNumber']
                "
              >
                {{ errors["AccountNumber"] }}
              </div>
            </div>
          </div>
        </div>
        <div class="half-content">
          <div class="col-md-l">
            <label>
              {{
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .accountName
              }}
              <span class="s-require">*</span>
            </label>
            <div class="container-input">
              <misa-input
                ref="AccountName"
                v-model="account.AccountName"
                :class="{ 'border-red': isBorderRed.AccountName }"
                @input="setIsBorderRed('AccountName')"
                @mouseenter="isHovering.AccountName = true"
                @mouseleave="isHovering.AccountName = false"
              ></misa-input>
              <div
                class="misa-tooltip"
                v-if="
                  isHovering.AccountName &&
                  (isBorderRed.AccountName || !account.AccountName) &&
                  errors['AccountName']
                "
              >
                {{ errors["AccountName"] }}
              </div>
            </div>
          </div>
        </div>
        <div class="half-content">
          <div class="col-md-l">
            <label>
              {{
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .accountNameEnglish
              }}
            </label>
            <div class="container-input">
              <misa-input
                ref="AccountNameEnglish"
                v-model="account.AccountNameEnglish"
                :class="{ 'border-red': isBorderRed.AccountNameEnglish }"
                @input="setIsBorderRed('AccountNameEnglish')"
                @mouseenter="isHovering.AccountNameEnglish = true"
                @mouseleave="isHovering.AccountNameEnglish = false"
              ></misa-input>
              <div
                class="misa-tooltip"
                v-if="
                  isHovering.AccountNameEnglish &&
                  isBorderRed.AccountNameEnglish
                "
              >
                {{ errors["AccountNameEnglish"] }}
              </div>
            </div>
          </div>
        </div>
        <div class="half-content">
          <div class="col-md-half">
            <label>
              {{
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .accountGeneral
              }}
            </label>
            <misa-form-combobox
              :isBorderRedFormCBB="isBorderRed"
              :entityFormCBB="account"
              :errorsFormCBB="errors"
              :listEntitySearchFormCBB="accounts"
              :propName="'AccountName'"
              :valueInput="valueInputFormCBB"
              :propCode="'AccountNumber'"
              :propBorderRed="'ParentId'"
              :textColFirst="
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .accountNumber
              "
              :textColSecond="
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .accountName
              "
            ></misa-form-combobox>
          </div>
          <div class="col-md-half" style="position: relative">
            <label>
              {{
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .nature
              }}
              <span class="s-require">*</span>
            </label>
            <misa-combobox
              :isBorderRedCBB="isBorderRed"
              :entityCBB="account"
              :errorsCBB="errors"
              :listEntitySearchCBB="listNatureSearch"
              :propName="'Nature'"
              :propId="'NatureId'"
            ></misa-combobox>
          </div>
        </div>
        <div class="full-content-area">
          <div class="col-md-l">
            <label
              >{{
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .explain
              }}
            </label>
            <misa-input-textarea
              v-model="account.Explain"
            ></misa-input-textarea>
          </div>
        </div>
        <div class="full-content">
          <div class="entity-check">
            <input type="checkbox" />
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                .foreignCurrencyAccounting
            }}</span>
          </div>
        </div>
        <div class="system-account-track-detail">
          <div class="title-track-detail">
            <div class="title-track-detail-icon">
              <div class="function-icon" style="scale: 1.5 1.5"></div>
            </div>
            <div class="title-track-detail-text">
              {{
                this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
                  .trackDetail
              }}
            </div>
          </div>
          <div class="content-track-detail">
            <div class="content-track-detail-row">
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input
                    type="checkbox"
                    :checked="account.UserObject > 0 && account.UserObject"
                    @click="handleToggleCheckbox('UserObject')"
                  />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.obj
                  }}</span>
                </div>
                <misa-select-option
                  :listData="listUserObject"
                  :propCode="'UserObjectCode'"
                  :propName="'UserObjectName'"
                  :valueSelected="setValueInputSelectOption"
                  :isDisabledMenu="!account.UserObject"
                ></misa-select-option>
              </div>
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.bankAccount
                  }}</span>
                </div>
              </div>
            </div>
            <div class="content-track-detail-row">
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.objTHCP
                  }}</span>
                </div>
                <misa-select-option :isDisabledMenu="true"></misa-select-option>
              </div>
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.construction
                  }}</span>
                </div>
                <misa-select-option :isDisabledMenu="true"></misa-select-option>
              </div>
            </div>
            <div class="content-track-detail-row">
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.order
                  }}</span>
                </div>
                <misa-select-option :isDisabledMenu="true"></misa-select-option>
              </div>
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.contractSale
                  }}</span>
                </div>
                <misa-select-option :isDisabledMenu="true"></misa-select-option>
              </div>
            </div>
            <div class="content-track-detail-row">
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.contractPurchase
                  }}</span>
                </div>
                <misa-select-option :isDisabledMenu="true"></misa-select-option>
              </div>
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.itemCP
                  }}</span>
                </div>
                <misa-select-option :isDisabledMenu="true"></misa-select-option>
              </div>
            </div>
            <div class="content-track-detail-row">
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.unit
                  }}</span>
                </div>
                <misa-select-option :isDisabledMenu="true"></misa-select-option>
              </div>
              <div class="content-track-detail-halfrow">
                <div class="entity-check">
                  <input type="checkbox" />
                  <span>{{
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .textProperty.rawCode
                  }}</span>
                </div>
                <misa-select-option :isDisabledMenu="true"></misa-select-option>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="form-detail-action">
        <div class="action-left">
          <misa-button-extra
            :textButtonExtra="
              this.$_MISAResource[this.$_LANG_CODE].BUTTON.CANCEL
            "
            @click="btnCancel"
          ></misa-button-extra>
        </div>
        <div class="action-right">
          <misa-button-extra
            :textButtonExtra="this.$_MISAResource[this.$_LANG_CODE].BUTTON.SAVE"
            @click="btnSave"
            :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.SAVE"
          ></misa-button-extra>
          <misa-button-default
            :textButtonDefault="
              this.$_MISAResource[this.$_LANG_CODE].BUTTON.SAVE_AND_ADD
            "
            @click="btnSaveAndAdd"
            :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.SAVE_AND_ADD"
          ></misa-button-default>
        </div>
      </div>
    </div>
  </div>
  <!-- dialog acoount input data not blank -->
  <misa-dialog-data-not-null
    v-if="isShowDialogDataNotNull"
    :valueNotNull="dataNotNull"
    :title="this.$_MISAResource[this.$_LANG_CODE].DIALOG.TITLE.DATA_INVALID"
  ></misa-dialog-data-not-null>
  <!-- dialog acoount id Exist -->
  <misa-dialog-data-exist
    v-if="isShowDialogCodeExist"
    :textProp="
      this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
        .accountNumber
    "
    :textEntityCodeExist="contentAccountNumberExist"
  ></misa-dialog-data-exist>
  <!-- dialog acoount save and close -->
  <misa-dialog-data-change
    v-if="isShowDialogDataChange"
  ></misa-dialog-data-change>
</template>

<script>
import accountService from "@/services/account.js";
import helperCommon from "@/scripts/helper.js";

export default {
  name: "SystemAccountDetail",

  props: ["accountSelected", "statusFormMode"],

  created() {
    this.loadData();

    this.getAllAccount();

    this.$_MISAEmitter.on("cancelDialogDataChange", () => {
      this.onCancelDialogDataChange();
    });
    this.$_MISAEmitter.on("noDialogDataChange", () => {
      this.onNoDialogDataChange();
    });
    this.$_MISAEmitter.on("yesDialogDataChange", async () => {
      await this.onYesDialogDataChange();
    });

    this.$_MISAEmitter.on("closeDialogCodeExist", () => {
      this.btnCloseDialogIdExist();
    });

    this.$_MISAEmitter.on("closeDialogDataError", () => {
      this.onCloseDialogSaveAndAdd();
    });

    this.$_MISAEmitter.on("onSelectedEntityCBB", (data) => {
      this.onSelectedDepartment(data);
    });

    this.$_MISAEmitter.on("onSelectedSelectOption", (data, prop) => {
      this.account[prop] = data;
    });

    this.$_MISAEmitter.on("onSelectedEntityFormCBB", (data) => {
      this.selectedGeneralAccount(data);
    });
  },

  mounted() {
    // focus vào ô đầu tiên khi mở form chi tiết
    this.focusCode();
    this.setValueInputFormCBB();
    // Đăng kí các sự kiện
    this.$refs.FormDetailSystemAccount.addEventListener(
      "keydown",
      this.handleKeyDown
    );
  },

  data() {
    return {
      // Khai báo mảng lưu các thuộc tính cần validate theo thứ tự, phục vụ cho việc focus, hiển thị lỗi theo thứ tự
      accountProperty: [
        "AccountNumber",
        "AccountName",
        "AccountNameEnglish",
        "ParentId",
        "Nature",
        "Explain",
      ],
      // Khai báo đối tượng employee
      account: {},
      // Khai báo danh sách đơn vị tìm kiếm
      listNatureSearch: [
        { Id: 1, Nature: "Dư nợ" },
        { Id: 2, Nature: "Dư có" },
        { Id: 3, Nature: "Lưỡng tính" },
        { Id: 4, Nature: "Không có số dư" },
      ],
      // Khai báo danh sách đối tượng người dùng
      listUserObject: [
        { UserObjectCode: 1, UserObjectName: "Khách hàng" },
        { UserObjectCode: 2, UserObjectName: "Nhà cung cấp" },
        { UserObjectCode: 3, UserObjectName: "Nhân viên" },
      ],
      // Khai báo trạng thái hiển thị của dialog cảnh báo dữ liệu k được để trống
      isShowDialogDataNotNull: false,
      // Khai báo biến xác định nội dung trường nào k được để trống
      dataNotNull: [],
      // Khai báo trạng thái hiển thị của dialog cảnh báo mã nhân viên đã tồn tại
      isShowDialogCodeExist: false,
      // Khai báo biến xác định thông tin của mã nhân viên đã tồn tại
      contentAccountNumberExist: "",
      // Khai báo biến quy định trang thái hiển thị dialog dữ liệu đã bị thay đổi
      isShowDialogDataChange: false,
      // Khai báo biến xác định border red
      isBorderRed: {},
      // Khai báo biến lưu title form mode
      titleFormMode: this.$_MISAResource[this.$_LANG_CODE].FORM.ADD_EMPLOYEE,
      // Khai báo biến chứa danh sách đối tượng lỗi
      errors: {},
      // Khai báo biến chứa danh sách các ô input khi hover
      isHovering: {},
      // Khai báo biến quy định trạng thái hiển thị menu tài khoản tổng hợp
      isShowMenuGeneralAccount: false,
      // Biến chứa danh sách tất cả tài khoản
      accounts: [],
      // Khai báo biến tìm kiếm tài khoản tổng hợp
      searchGeneralAccount: "",
      // Trang hiện tại
      pageNumber: 1,
      // Số lượng tài khoản được tải mỗi lần
      pageSize: 10,
      // Giá trị của input trong form cbb
      valueInputFormCBB: "",
    };
  },

  computed: {
    setValueInputSelectOption() {
      let res = "";

      if (this.account.UserObject == 1) {
        res = "Khách hàng";
      } else if (this.account.UserObject == 2) {
        res = "Nhà cung cấp";
      } else if (this.account.UserObject == 3) {
        res = "Nhân viên";
      }

      return res;
    },
  },

  methods: {
    /**
     * Mô tả: gọi api lấy dữ liệu
     * created by : BNTIEN
     * created date: 22-07-2023 14:51:10
     */
    async loadData() {
      try {
        // Nếu form ở trạng thái thêm mới
        // Chuyển đối tượng sang chuỗi json
        let res = JSON.stringify(this.accountSelected);
        // Chuyển đổi chuỗi json thành đối tượng employee
        this.account = JSON.parse(res);
        // Tính chất mặc định là dư nợ
        if (!this.account.Nature) {
          this.account.Nature = this.listNatureSearch[0].Nature;
        }
        if (this.statusFormMode !== this.$_MISAEnum.FORM_MODE.Edit) {
          // Gán title cho form mode thêm mới
          this.titleFormMode =
            this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.titleAdd;
        } else {
          // Gán title cho form mode thêm sửa
          this.titleFormMode =
            this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.titleEdit;
        }
      } catch {
        return;
      }
    },

    /**
     * Mô tả: Lấy dữ liệu combobox tài khoản tổng hợp
     * created by : BNTIEN
     * created date: 23-07-2023 12:22:30
     */
    async getAllAccount() {
      try {
        const res = await accountService.getFilter(
          this.pageSize,
          this.pageNumber,
          "",
          true,
          1,
          ""
        );
        if (res.data.Data.length > 0) {
          this.accounts = [...this.accounts, ...res.data.Data];
          this.pageNumber++;
        }
        let parents = [];
        // Lấy danh sách các dòng hện đang là cha trong dataTable
        parents = this.accounts.filter(
          (row) => row.IsParent == this.$_MISAEnum.BOOL.TRUE
        );
        // Duyệt đến khi không có dòng nào là cha nữa
        while (parents.length > 0) {
          // Lấy danh sách tất cả các con của phần tử đầu tiên trong danh sách các dòng có con
          const childrens = await accountService.getAllChildren(
            parents[0].AccountNumber
          );
          // Thêm vào dataTable
          this.accounts.splice(
            this.accounts.indexOf(parents[0]) + 1,
            0,
            ...childrens.data
          );
          // Cập nhật trạng thái cho các dòng vừa mới thêm vào dataTable
          for (const row of childrens.data) {
            // Kiểm tra xem trong số những dòng con vừa tìm được có dòng nào là cha của các dòng khác không
            if (row.IsParent == this.$_MISAEnum.BOOL.TRUE) {
              // Thêm dòng cha mới vào danh sách các dòng hiện đang là cha
              parents.push(row);
            }
          }

          // Xóa phần tử đầu tiên trong danh sách những dòng hiện đang là cha sau khi đã duyệt xong
          parents.splice(0, 1);
        }
      } catch {
        this.accounts = [];
      }
    },

    /**
     * Mô tả: Hàm focus vào ô input số tài khoản
     * created by : BNTIEN
     * created date: 23-07-2023 12:23:21
     */
    focusCode() {
      this.$refs.AccountNumber.focus();
    },

    /**
     * Mô tả: Hàm kiểm tra xem employee có thay đổi sau khi mở form detail không
     * created by : BNTIEN
     * created date: 23-07-2023 12:23:51
     */
    hasDataChanged() {
      return (
        JSON.stringify(this.accountSelected) !== JSON.stringify(this.account)
      );
    },
    /**
     * Mô tả: Hàm sử lí sự kiện khi click vào icon close
     * created by : BNTIEN
     * created date: 23-07-2023 12:23:51
     */
    async onCloseFormDetail() {
      // Kiểm tra xem giữ liệu có thay đổi hay không (Trường hợp có thay đổi)
      if (this.hasDataChanged()) {
        this.isShowDialogDataChange = true;
      } else {
        this.$emit("closeFormDetail");
      }
    },

    /**
     * Mô tả: Hàm chọn giá trị tài khoản tổng hợp
     * created by : BNTIEN
     * created date: 23-07-2023 12:24:37
     */
    selectedGeneralAccount(item) {
      this.account.ParentId = item.AccountId;
      this.valueInputFormCBB = item.AccountNumber;
      this.isBorderRed.ParentId = false;
    },

    /**
     * Mô tả: Hàm set các lỗi nhập liệu phía fontend
     * created by : BNTIEN
     * created date: 23-07-2023 12:24:37
     */
    setError(key) {
      try {
        this.errors[key] =
          this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.validateNotNull[
            key
          ];
        this.isBorderRed[key] = true;
        this.dataNotNull.push(
          this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.validateNotNull[
            key
          ]
        );
      } catch {
        return;
      }
    },

    /**
     * Mô tả: Hàm set các lỗi nhập liệu phía fontend
     * created by : BNTIEN
     * created date: 23-07-2023 12:24:37
     */
    setErrorMaxLength(key) {
      try {
        this.errors[key] =
          this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.maxLength[
            key
          ].Warning;
        this.isBorderRed[key] = true;
        this.dataNotNull.push(
          this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.maxLength[key]
            .Warning
        );
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Validate lỗi nhập liệu phía fontend
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:16
     */
    validateAccount() {
      try {
        for (const refInput of this.accountProperty) {
          switch (refInput) {
            case "AccountNumber":
              if (helperCommon.isEmptyInput(this.account[refInput])) {
                this.setError(refInput);
              } else if (
                helperCommon.isMaxLengthInput(
                  this.account[refInput],
                  this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.maxLength[
                    refInput
                  ].Limit
                )
              ) {
                this.setErrorMaxLength(refInput);
              } else if (
                helperCommon.isMinLengthInput(
                  this.account[refInput],
                  this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.minLength[
                    refInput
                  ].MinLength
                )
              ) {
                this.errors[refInput] =
                  this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.minLength[
                    refInput
                  ].Warning;
                this.isBorderRed[refInput] = true;
                this.dataNotNull.push(
                  this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.minLength[
                    refInput
                  ].Warning
                );
              }
              break;
            case "AccountName":
            case "Nature":
              if (helperCommon.isEmptyInput(this.account[refInput])) {
                this.setError(refInput);
              } else if (
                helperCommon.isMaxLengthInput(
                  this.account[refInput],
                  this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.maxLength[
                    refInput
                  ].Limit
                )
              ) {
                this.setErrorMaxLength(refInput);
              }
              break;
            default:
              if (this.account[refInput]) {
                if (
                  helperCommon.isMaxLengthInput(
                    this.account[refInput],
                    this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                      .maxLength[refInput].Limit
                  )
                ) {
                  this.setErrorMaxLength(refInput);
                }
              }
              break;
          }
        }
      } catch {
        return;
      }
    },
    /**
     * Mô tả:  Hàm xử lí lỗi nhập liệu người dùng khi backend trả về lỗi
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:25
     */
    handleErrorInputAccount(errors, accountProperty) {
      const responseHandle = helperCommon.handleErrorInput(
        errors,
        accountProperty
      );
      this.errors = responseHandle.error;
      this.isBorderRed = responseHandle.isBorderRed;
      this.dataNotNull = responseHandle.dataNotNull;
      if (this.dataNotNull.length > 0) {
        this.isShowDialogDataNotNull = true;
      }
    },
    /**
     * Mô tả: Hàm kiểm tra xem số tài khoản đã tồn tại trong database hay chưa
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    async checkAccountExists() {
      try {
        const res = await accountService.getByCode(this.account.AccountNumber);
        return res.data;
      } catch {
        return null;
      }
    },
    /**
     * Mô tả: Hàm xử lí khi số tài khoản đã tồn tại trong hệ thống
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    handleEmployeeExisted(accountExisted) {
      this.isShowDialogCodeExist = true;
      this.isBorderRed.AccountNumber = true;
      this.errors["AccountNumber"] = `${
        this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form.textProperty
          .accountNumber
      }
       ${accountExisted.AccountNumber} ${
        this.$_MISAResource[this.$_LANG_CODE].DIALOG.CONTENT.EXIST_DETAIL_END
      }`;
      this.contentAccountNumberExist = accountExisted.AccountNumber;
    },
    /**
     * Mô tả: Hàm xử lí sự kiện khi người dùng chọn đơn vị
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    onSelectedDepartment(nature) {
      this.account.Nature = nature.Nature;
      this.isBorderRed.Nature = false;
    },
    /**
     * Mô tả: Hàm xử lí sự kiện khi người dùng bấm vào nút cất trên form chi tiết
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    async btnSave() {
      if (this.statusFormMode === this.$_MISAEnum.FORM_MODE.Add) {
        this.validateAccount();
        if (this.dataNotNull.length > 0) {
          this.isShowDialogDataNotNull = true;
        } else {
          try {
            // Kiểm tra xem mã nhân viên đã tồn tại trong database chưa, nếu đã tồn tại thì thông báo cho người dùng
            let accountByNumber = await this.checkAccountExists();
            if (!accountByNumber) {
              // Nếu mã nhân viên chưa tồn tại trong hệ thống
              const res = await accountService.create(this.account);
              if (
                this.$_MISAEnum.CHECK_STATUS.isResponseStatusCreated(
                  res.status
                ) &&
                res.data > 0
              ) {
                this.$_MISAEmitter.emit(
                  "onShowToastMessage",
                  this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
                    .SUCCESS_CTEATE
                );
                this.$emit("closeFormDetail");
                this.$_MISAEmitter.emit("refreshDataTable");
              }
            } else {
              // Nếu mã nhân viên đã tồn tại trong hệ thống
              this.handleEmployeeExisted(accountByNumber);
            }
          } catch (error) {
            this.handleErrorInputAccount(error, this.accountProperty);
          }
        }
      } else {
        // Nếu form ở trạng thái sửa
        // Kiểm tra xem dữ liệu có thay đổi hay k (Trường hợp đã thay đổi)
        if (this.hasDataChanged()) {
          this.validateAccount();
          if (this.dataNotNull.length > 0) {
            this.isShowDialogDataNotNull = true;
          } else {
            try {
              // Kiểm tra xem mã nhân viên đã tồn tại trong database chưa, nếu đã tồn tại thì thông báo cho người dùng
              let accountByNumber = await this.checkAccountExists();
              // Nếu mã nhân viên chưa tồn tại trong hệ thống hoặc tồn tại nhưng trùng với nhân viên đang sửa
              if (
                !accountByNumber ||
                accountByNumber.AccountNumber ===
                  this.accountSelected.AccountNumber
              ) {
                const res = await accountService.update(
                  this.accountSelected.AccountId,
                  this.account
                );
                if (
                  this.$_MISAEnum.CHECK_STATUS.isResponseStatusOk(res.status) &&
                  res.data > 0
                ) {
                  this.$_MISAEmitter.emit(
                    "onShowToastMessageUpdate",
                    this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
                      .SUCCESS_UPDATE
                  );
                  this.$emit("closeFormDetail");
                  this.$_MISAEmitter.emit("refreshDataTable");
                }
              } else {
                // Nếu mã nhân viên đã tồn tại trong hệ thống
                this.handleEmployeeExisted(accountByNumber);
              }
            } catch (error) {
              this.handleErrorInputAccount(error, this.accountProperty);
            }
          }
        } else {
          this.$emit("closeFormDetail");
        }
      }
      // }
    },
    /**
     * Mô tả: Hàm xử lí sự kiện khi người dùng bấm vào nut cất và thêm trên form chi tiết
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    async btnSaveAndAdd() {
      // Nếu form ở trạng thái thêm mới
      if (this.statusFormMode === this.$_MISAEnum.FORM_MODE.Add) {
        this.validateAccount();
        if (this.dataNotNull.length > 0) {
          this.isShowDialogDataNotNull = true;
        } else {
          try {
            // Kiểm tra xem mã nhân viên đã tồn tại trong database chưa, nếu đã tồn tại thì thông báo cho người dùng
            let accountByNumber = await this.checkAccountExists();
            if (!accountByNumber) {
              // Nếu mã nhân viên chưa tồn tại trong hệ thống
              const res = await accountService.create(this.account);
              if (
                this.$_MISAEnum.CHECK_STATUS.isResponseStatusCreated(
                  res.status
                ) &&
                res.data > 0
              ) {
                this.$_MISAEmitter.emit(
                  "onShowToastMessage",
                  this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
                    .SUCCESS_CTEATE
                );
                this.account = {};
                this.isBorderRed = {};
                this.$_MISAEmitter.emit("refreshDataTable");
                this.focusCode();
              }
            } else {
              // Nếu mã nhân viên đã tồn tại trong hệ thống
              this.handleEmployeeExisted(accountByNumber);
            }
          } catch (error) {
            this.handleErrorInputAccount(error, this.accountProperty);
          }
        }
        // Nếu form ở trạng thái sửa
      } else {
        // Kiểm tra xem dữ liệu có thay đổi hay k
        if (this.hasDataChanged()) {
          this.validateAccount();
          if (this.dataNotNull.length > 0) {
            this.isShowDialogDataNotNull = true;
          } else {
            try {
              // Kiểm tra xem mã nhân viên đã tồn tại trong database chưa, nếu đã tồn tại thì thông báo cho người dùng
              let accountByNumber = await this.checkAccountExists();
              // Nếu mã nhân viên chưa tồn tại trong hệ thống hoặc tồn tại trùng với nhân viên đang sửa
              if (
                !accountByNumber ||
                accountByNumber.AccountNumber ===
                  this.accountSelected.AccountNumber
              ) {
                const res = await accountService.update(
                  this.accountSelected.AccountId,
                  this.account
                );
                this.account = {};
                this.$_MISAEmitter.emit("setFormModeAdd");
                this.focusCode();
                this.$_MISAEmitter.emit("refreshDataTable");
                if (
                  this.$_MISAEnum.CHECK_STATUS.isResponseStatusOk(res.status) &&
                  res.data > 0
                ) {
                  this.$_MISAEmitter.emit(
                    "onShowToastMessageUpdate",
                    this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
                      .SUCCESS_UPDATE
                  );
                }
              } else {
                // Nếu mã nhân viên đã tồn tại trong hệ thống
                this.handleEmployeeExisted(accountByNumber);
              }
            } catch (error) {
              this.handleErrorInputAccount(error, this.accountProperty);
            }
          }
        } else {
          this.account = {};
          this.$_MISAEmitter.emit("setFormModeAdd");
          this.focusCode();
        }
      }
    },
    /**
     * Mô tả: Hàm đóng dialog cảnh báo dữ liệu k được để trống và focus vào các ô trống
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    onCloseDialogSaveAndAdd() {
      this.isShowDialogDataNotNull = false;
      this.dataNotNull = [];
      let listPropError = [];
      for (const key in this.isBorderRed) {
        if (this.isBorderRed[key] === true) {
          listPropError.push(key);
        }
      }

      for (const prop of this.accountProperty) {
        if (listPropError.includes(prop)) {
          if (prop === "Nature") {
            this.$nextTick(() => {
              this.$_MISAEmitter.emit("focusInputCBB");
            });
          } else if (prop === "ParentId") {
            this.$nextTick(() => {
              this.$_MISAEmitter.emit("focusInputFormCBB");
            });
          } else {
            // đợi DOM cập nhật trước khi thực thi focus
            this.$nextTick(() => {
              this.$refs[prop].focus();
            });
          }
          return;
        }
      }
    },

    /**
     * Mô tả: Hàm bỏ border red khi dữ liệu thay đổi
     * created by : BNTIEN
     * created date:23-07-2023 12:26:43
     */
    setIsBorderRed(prop) {
      if (prop in this.isBorderRed) {
        this.isBorderRed[prop] = false;
      }
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi click vào nút hủy trong form chi tiết
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    btnCancel() {
      this.$emit("closeFormDetail");
    },
    /**
     * Mô tả: Hàm xử lí sự kiện đóng dialog cảnh báo số tài khoản đã tồn tại
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    btnCloseDialogIdExist() {
      this.isShowDialogCodeExist = false;
      this.focusCode();
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi bấm vào button hủy trong dialog dữ liệu đã bị thay đổi
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    onCancelDialogDataChange() {
      this.isShowDialogDataChange = false;
      this.focusCode();
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi bấm vào button không trong dialog dữ liệu đã bị thay đổi
     * created by : BNTIEN
     * created date:23-07-2023 12:26:43
     */
    onNoDialogDataChange() {
      this.$emit("closeFormDetail");
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi bấm vào button có trong dialog dữ liệu đã bị thay đổi
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    async onYesDialogDataChange() {
      this.isShowDialogDataChange = false;
      await this.btnSave();
    },

    /**
     * Mô tả: Hàm reset tabindex về ô inputsố tài khoản khi tab nhảy đến icon close
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    resetTab() {
      this.focusCode();
    },

    /**
     * Mô tả: xử lí sự kiện khi bấm esc khi đang ở form detail
     * created by : BNTIEN
     * created date: 23-07-2023 12:26:43
     */
    async handleKeyDown(event) {
      if (event.key === "Escape") {
        // Nếu phím được nhấn là Esc, thực hiện hàm onCloseFormDetail
        await this.onCloseFormDetail();
      } else if (event.ctrlKey && event.key === "s") {
        event.preventDefault(); // Ngăn chặn hành động mặc định của trình duyệt khi nhấn phím Ctrl + S
        this.btnSave();
      } else if (event.ctrlKey && event.shiftKey && event.key === "S") {
        event.preventDefault(); // Ngăn chặn hành động mặc định của trình duyệt khi nhấn tổ hợp phím Ctrl + Shift + S
        this.btnSaveAndAdd();
      }
    },

    /**
     * Mô tả: Xử lí hàm toggle checkbox
     * created by : BNTIEN
     * created date: 26-07-2023 13:45:49
     */
    handleToggleCheckbox(prop) {
      try {
        if (!this.account[prop]) {
          this.account[prop] = 1;
          this.$_MISAEmitter.emit("selectedDefaultItem");
        } else {
          this.account[prop] = null;
          this.$_MISAEmitter.emit("unSelectedDefaultItem");
        }
      } catch {
        return;
      }
    },

    /**
     * Mô tả: Hàm lấy accountNumber cha
     * created by : BNTIEN
     * created date: 26-07-2023 21:24:47
     */
    async setValueInputFormCBB() {
      if (this.account.ParentId) {
        try {
          const parent = await accountService.getById(this.account.ParentId);
          this.valueInputFormCBB = parent.data.AccountNumber;
        } catch {
          return;
        }
      }
    },
  },

  beforeUnmount() {
    this.$_MISAEmitter.off("cancelDialogDataChange");
    this.$_MISAEmitter.off("noDialogDataChange");
    this.$_MISAEmitter.off("yesDialogDataChange");
    this.$_MISAEmitter.off("closeDialogCodeExist");
    this.$_MISAEmitter.off("closeDialogDataError");
    this.$_MISAEmitter.off("onSelectedEntityCBB");
    this.$_MISAEmitter.off("onSelectedSelectOption");
    this.$_MISAEmitter.off("onSelectedEntityFormCBB");
  },
};
</script>

<style scoped>
@import url(./SystemAccountDetail.css);

.border-red {
  border: 1px solid red;
}

.text-bold {
  font-weight: 700;
}

input:not(.form-cbb .e-textfield-cbb input) {
  height: 26px;
}

#detail-add-system-account input[type="checkbox"] {
  height: 16px;
}
</style>
