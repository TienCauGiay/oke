<template>
  <div
    id="detail-info-provider"
    class="position-display-center"
    ref="FormDetailProvider"
  >
    <div class="form-detail-toolbar">
      <div
        class="question-icon icon-tb"
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.HELP"
      ></div>
      <div
        @click="onCloseFormDetail"
        class="close-icon icon-tb"
        @keydown.tab.prevent="resetTab($event.target.value)"
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.EXIST"
      ></div>
    </div>
    <div class="form-detail-main">
      <div class="provider-title">
        <p>
          <b>Thông tin nhà cung cấp</b>
        </p>
        <div class="entity-check">
          <input
            type="radio"
            name="typeObject"
            :checked="!this.provider.IsPersonal"
            @click="handleClickInstitute"
          />
          <span>Tổ chức</span>
        </div>
        <div class="entity-check">
          <input
            type="radio"
            name="typeObject"
            :checked="this.provider.IsPersonal"
            @click="handleClickPersonal"
          />
          <span>Cá nhân</span>
        </div>
        <div class="entity-check" id="provider-title-input-checkbox">
          <input
            type="checkbox"
            :checked="provider.IsCustomer"
            @click="toggleCheckboxCustomer"
          />
          <span>Là khách hàng</span>
        </div>
      </div>
      <div class="form-detail-content">
        <!-- Là tổ chức -->
        <template v-if="!this.provider.IsPersonal">
          <div class="half-content">
            <div class="col-md-n">
              <label> Mã số thuế </label>
              <div class="container-input">
                <misa-input
                  v-model="provider.TaxCode"
                  ref="TaxCode"
                  :class="{ 'border-red': isBorderRed.TaxCode }"
                  @input="setIsBorderRed('TaxCode')"
                  @mouseenter="isHovering.TaxCode = true"
                  @mouseleave="isHovering.TaxCode = false"
                ></misa-input>
                <div
                  class="misa-tooltip"
                  v-if="isHovering.TaxCode && isBorderRed.TaxCode"
                >
                  {{ errors["TaxCode"] }}
                </div>
              </div>
            </div>
            <div class="col-md-tb">
              <label>
                Mã nhà cung cấp
                <span class="s-require">*</span>
              </label>
              <div class="container-input">
                <misa-input
                  ref="ProviderCode"
                  v-model="provider.ProviderCode"
                  :class="{ 'border-red': isBorderRed.ProviderCode }"
                  @input="setIsBorderRed('ProviderCode')"
                  @mouseenter="isHovering.ProviderCode = true"
                  @mouseleave="isHovering.ProviderCode = false"
                ></misa-input>
                <div
                  class="misa-tooltip"
                  v-if="
                    isHovering.ProviderCode &&
                    (isBorderRed.ProviderCode || !provider.ProviderCode) &&
                    errors['ProviderCode']
                  "
                >
                  {{ errors["ProviderCode"] }}
                </div>
              </div>
            </div>
          </div>
          <div class="half-content">
            <div class="col-md-n">
              <label>Điện thoại</label>
              <div class="container-input">
                <misa-input
                  v-model="provider.PhoneNumber"
                  ref="PhoneNumber"
                  :class="{ 'border-red': isBorderRed.PhoneNumber }"
                  @input="setIsBorderRed('PhoneNumber')"
                  @mouseenter="isHovering.PhoneNumber = true"
                  @mouseleave="isHovering.PhoneNumber = false"
                ></misa-input>
                <div
                  class="misa-tooltip"
                  v-if="isHovering.PhoneNumber && isBorderRed.PhoneNumber"
                >
                  {{ errors["PhoneNumber"] }}
                </div>
              </div>
            </div>
            <div class="col-md-tb">
              <label> Website </label>
              <div class="container-input">
                <misa-input
                  v-model="provider.Website"
                  ref="Website"
                  :class="{ 'border-red': isBorderRed.Website }"
                  @input="setIsBorderRed('Website')"
                  @mouseenter="isHovering.Website = true"
                  @mouseleave="isHovering.Website = false"
                ></misa-input>
                <div
                  class="misa-tooltip"
                  v-if="isHovering.Website && isBorderRed.Website"
                >
                  {{ errors["Website"] }}
                </div>
              </div>
            </div>
          </div>
          <div class="half-content">
            <div class="col-md-l">
              <label>
                Tên nhà cung cấp
                <span class="s-require">*</span>
              </label>
              <div class="container-input">
                <misa-input
                  ref="ProviderName"
                  v-model="provider.ProviderName"
                  :class="{ 'border-red': isBorderRed.ProviderName }"
                  @input="setIsBorderRed('ProviderName')"
                  @mouseenter="isHovering.ProviderName = true"
                  @mouseleave="isHovering.ProviderName = false"
                ></misa-input>
                <div
                  class="misa-tooltip"
                  v-if="
                    isHovering.ProviderName &&
                    (isBorderRed.ProviderName || !provider.ProviderName) &&
                    errors['ProviderName']
                  "
                >
                  {{ errors["ProviderName"] }}
                </div>
              </div>
            </div>
          </div>
          <div class="half-content" id="group-provider">
            <div class="col-md-l">
              <label> Nhóm nhà cung cấp </label>
              <misa-combobox-multiple
                :isSelectMultiple="true"
              ></misa-combobox-multiple>
            </div>
          </div>
          <div class="half-content-2">
            <div class="col-md-l">
              <label>Địa chỉ</label>
              <div class="container-input">
                <misa-input-textarea
                  v-model="provider.Address"
                  ref="Address"
                  :class="{ 'border-red': isBorderRed.Address }"
                  @input="setIsBorderRed('Address')"
                  @mouseenter="isHovering.Address = true"
                  @mouseleave="isHovering.Address = false"
                  :placeholder="'VD: Số 82 Duy Tân, Dịch Vọng'"
                ></misa-input-textarea>
                <div
                  class="misa-tooltip"
                  v-if="isHovering.Address && isBorderRed.Address"
                >
                  {{ errors["Address"] }}
                </div>
              </div>
            </div>
          </div>
          <div class="half-content">
            <div class="col-md-l">
              <label>Nhân viên mua hàng</label>
              <misa-combobox-multiple
                :isSelectMultiple="false"
              ></misa-combobox-multiple>
            </div>
          </div>
        </template>
        <!-- Là cá nhân -->
        <div class="half-content" v-if="this.provider.IsPersonal">
          <div class="col-md-tb">
            <label>
              Mã nhà cung cấp
              <span class="s-require">*</span>
            </label>
            <div class="container-input">
              <misa-input
                ref="ProviderCode"
                v-model="provider.ProviderCode"
                :class="{ 'border-red': isBorderRed.ProviderCode }"
                @input="setIsBorderRed('ProviderCode')"
                @mouseenter="isHovering.ProviderCode = true"
                @mouseleave="isHovering.ProviderCode = false"
              ></misa-input>
              <div
                class="misa-tooltip"
                v-if="
                  isHovering.ProviderCode &&
                  (isBorderRed.ProviderCode || !provider.ProviderCode) &&
                  errors['ProviderCode']
                "
              >
                {{ errors["ProviderCode"] }}
              </div>
            </div>
          </div>
          <div class="col-md-n">
            <label> Mã số thuế </label>
            <div class="container-input">
              <misa-input
                v-model="provider.TaxCode"
                ref="TaxCode"
                :class="{ 'border-red': isBorderRed.TaxCode }"
                @input="setIsBorderRed('TaxCode')"
                @mouseenter="isHovering.TaxCode = true"
                @mouseleave="isHovering.TaxCode = false"
              ></misa-input>
              <div
                class="misa-tooltip"
                v-if="isHovering.TaxCode && isBorderRed.TaxCode"
              >
                {{ errors["TaxCode"] }}
              </div>
            </div>
          </div>
        </div>
        <div class="half-content" v-if="this.provider.IsPersonal">
          <div class="col-md-l">
            <label>Nhóm nhà cung cấp</label>
            <misa-combobox-multiple
              :isSelectMultiple="true"
            ></misa-combobox-multiple>
          </div>
        </div>
        <div class="half-content" v-if="this.provider.IsPersonal">
          <div class="col-md-n" style="position: relative">
            <label>Tên nhà cung cấp <span class="s-require">*</span> </label>
            <misa-combobox
              :isBorderRedCBB="isBorderRed"
              :entityCBB="provider"
              :errorsCBB="errors"
              :listEntitySearchCBB="listNatureSearch"
              :propName="'Nature'"
              :propId="'NatureId'"
              :placeholderInputCBB="'Xưng hô'"
            ></misa-combobox>
          </div>
          <div class="col-md-tb">
            <label class="label-hide-text">a</label>
            <div class="container-input">
              <misa-input
                ref="ProviderName"
                v-model="provider.ProviderName"
                :class="{ 'border-red': isBorderRed.ProviderName }"
                @input="setIsBorderRed('ProviderName')"
                @mouseenter="isHovering.ProviderName = true"
                @mouseleave="isHovering.ProviderName = false"
                :placeholder="'Họ và tên'"
              ></misa-input>
              <div
                class="misa-tooltip"
                v-if="
                  isHovering.ProviderName &&
                  (isBorderRed.ProviderName || !provider.ProviderName) &&
                  errors['ProviderName']
                "
              >
                {{ errors["ProviderName"] }}
              </div>
            </div>
          </div>
        </div>
        <div class="half-content" v-if="this.provider.IsPersonal">
          <div class="col-md-l">
            <label>Nhân viên mua hàng</label>
            <misa-combobox-multiple
              :isSelectMultiple="false"
            ></misa-combobox-multiple>
          </div>
        </div>
        <div class="half-content-2" v-if="this.provider.IsPersonal">
          <div class="col-md-l">
            <label>Địa chỉ</label>
            <div class="container-input">
              <misa-input-textarea
                v-model="provider.Address"
                ref="Address"
                :class="{ 'border-red': isBorderRed.Address }"
                @input="setIsBorderRed('Address')"
                @mouseenter="isHovering.Address = true"
                @mouseleave="isHovering.Address = false"
                :placeholder="'VD: Số 82 Duy Tân, Dịch Vọng'"
              ></misa-input-textarea>
              <div
                class="misa-tooltip"
                v-if="isHovering.Address && isBorderRed.Address"
              >
                {{ errors["Address"] }}
              </div>
            </div>
          </div>
        </div>
        <div class="full-content-2">
          <div class="select-layout">
            <button
              class="select-layout-item"
              @click="handleSelectLayout('infoContact')"
              :class="{ 'active-layout': selectLayout.infoContact }"
            >
              Thông tin liên hệ
            </button>
            <button
              class="select-layout-item"
              @click="handleSelectLayout('termPayment')"
              :class="{ 'active-layout': selectLayout.termPayment }"
            >
              Điều khoản thanh toán
            </button>
            <button
              class="select-layout-item"
              @click="handleSelectLayout('bankAccount')"
              :class="{ 'active-layout': selectLayout.bankAccount }"
            >
              Tài khoản ngân hàng
            </button>
            <button
              class="select-layout-item"
              @click="handleSelectLayout('addressOther')"
              :class="{ 'active-layout': selectLayout.addressOther }"
            >
              Địa chỉ khác
            </button>
            <button
              class="select-layout-item"
              @click="handleSelectLayout('note')"
              :class="{ 'active-layout': selectLayout.note }"
            >
              Ghi chú
            </button>
          </div>
          <!-- Là Tổ chức nhưng không là khách hàng -->
          <div
            class="content-select-layout"
            v-if="
              !this.provider.IsPersonal &&
              selectLayout.infoContact &&
              !provider.IsCustomer
            "
          >
            <div class="content-select-layout-row">
              <div class="half-content">
                <div class="col-md-n" style="position: relative">
                  <label>Người liên hệ</label>
                  <misa-combobox
                    :isBorderRedCBB="isBorderRed"
                    :entityCBB="provider"
                    :errorsCBB="errors"
                    :listEntitySearchCBB="listNatureSearch"
                    :propName="'Nature'"
                    :propId="'NatureId'"
                    :placeholderInputCBB="'Xưng hô'"
                  ></misa-combobox>
                </div>
                <div class="col-md-tb">
                  <label class="label-hide-text">hide</label>
                  <misa-input :placeholder="'Họ và tên'"></misa-input>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-l">
                  <label>Đại diện theo PL</label>
                  <misa-input :placeholder="'Đại diện theo PL'"></misa-input>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row-2">
              <div class="half-content">
                <div class="col-md-l">
                  <misa-input :placeholder="'Email'"></misa-input>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row-2">
              <div class="half-content">
                <div class="col-md-tb">
                  <misa-input :placeholder="'Số điện thoại'"></misa-input>
                </div>
              </div>
            </div>
          </div>
          <!-- Là Tổ chức và là khách hàng -->
          <div
            class="content-select-layout"
            v-if="
              !this.provider.IsPersonal &&
              selectLayout.infoContact &&
              provider.IsCustomer
            "
          >
            <div class="content-select-layout-row">
              <div class="half-content">
                <div class="col-md-n" style="position: relative">
                  <label>Người liên hệ</label>
                  <misa-combobox
                    :isBorderRedCBB="isBorderRed"
                    :entityCBB="provider"
                    :errorsCBB="errors"
                    :listEntitySearchCBB="listNatureSearch"
                    :propName="'Nature'"
                    :propId="'NatureId'"
                    :placeholderInputCBB="'Xưng hô'"
                  ></misa-combobox>
                </div>
                <div class="col-md-tb">
                  <label class="label-hide-text">hide</label>
                  <misa-input :placeholder="'Họ và tên'"></misa-input>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-l">
                  <label>Người nhận hóa đơn điện tử</label>
                  <misa-input :placeholder="'Họ và tên'"></misa-input>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row-2">
              <div class="half-content">
                <div class="col-md-l">
                  <misa-input :placeholder="'Email'"></misa-input>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-l">
                  <misa-input
                    :placeholder="'Email (Ngăn cách nhiều Email bởi dấu chấm phẩy)'"
                  ></misa-input>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row-2">
              <div class="half-content">
                <div class="col-md-tb">
                  <misa-input :placeholder="'Số điện thoại'"></misa-input>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-tb">
                  <misa-input :placeholder="'Số điện thoại'"></misa-input>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row-2">
              <div class="half-content">
                <div class="col-md-l">
                  <label>Đại diện theo PL</label>
                  <misa-input :placeholder="'Đại diện theo PL'"></misa-input>
                </div>
              </div>
            </div>
          </div>
          <!-- Là cá nhân nhưng không là khách hàng -->
          <div
            class="content-select-layout"
            v-if="this.provider.IsPersonal && selectLayout.infoContact"
          >
            <div class="content-select-layout-row">
              <div class="half-content">
                <div class="col-md-l">
                  <label>Thông tin liên hệ</label>
                  <misa-input :placeholder="'Email'"></misa-input>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-half">
                  <label>Thông tin CMND/Thẻ căn cước</label>
                  <misa-input
                    :placeholder="'Số CMND/Thẻ căn cước'"
                  ></misa-input>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row-2">
              <div class="half-content">
                <div class="col-md-half">
                  <misa-input :placeholder="'Điện thoại di động'"></misa-input>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-half">
                  <misa-input type="date"></misa-input>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row-2">
              <div class="half-content">
                <div class="col-md-half">
                  <misa-input :placeholder="'Điện thoại cố định'"></misa-input>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-l">
                  <misa-input :placeholder="'Nơi cấp'"></misa-input>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row">
              <div class="half-content">
                <div class="col-md-l">
                  <label> Đại diện theo PL </label>
                  <misa-input :placeholder="'Đại diện theo PL'"></misa-input>
                </div>
              </div>
            </div>
          </div>

          <!-- Không là khách hàng -->
          <div
            class="content-select-layout"
            id="content-select-layout"
            v-if="selectLayout.termPayment && !provider.IsCustomer"
          >
            <div class="content-select-layout-row">
              <div class="full-content">
                <div class="full-content-quarter">
                  <div class="col-md-quater" style="position: relative">
                    <label>Điều khoản thanh toán</label>
                    <misa-combobox-multiple
                      :isSelectMultiple="false"
                    ></misa-combobox-multiple>
                  </div>
                  <div class="col-md-quater" style="position: relative">
                    <label>Số ngày được nợ</label>
                    <misa-input></misa-input>
                  </div>
                  <div class="col-md-quater" style="position: relative">
                    <label>Số nợ tối đa</label>
                    <misa-input></misa-input>
                  </div>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row">
              <div class="full-content">
                <div class="full-content-quarter">
                  <div
                    class="col-md-quater"
                    style="position: relative"
                    id="multiple-cbb-no-icon"
                  >
                    <label>Tài khoản công nợ phải trả</label>
                    <misa-form-combobox
                      :isBorderRedFormCBB="isBorderRed"
                      :entityFormCBB="provider"
                      :errorsFormCBB="errors"
                      :listEntitySearchFormCBB="accounts"
                      :propName="'AccountName'"
                      :valueInput="valueInputFormCBB"
                      :propCode="'AccountNumber'"
                      :propBorderRed="'ParentId'"
                      :textColFirst="
                        this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                          .textProperty.accountNumber
                      "
                      :textColSecond="
                        this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                          .textProperty.accountName
                      "
                    ></misa-form-combobox>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <!-- Là khách hàng -->
          <div
            class="content-select-layout"
            id="content-select-layout"
            v-if="selectLayout.termPayment && provider.IsCustomer"
          >
            <div class="content-select-layout-row">
              <div class="full-content">
                <div class="full-content-quarter">
                  <div class="col-md-quater" style="position: relative">
                    <label>Điều khoản thanh toán</label>
                    <misa-combobox-multiple
                      :isSelectMultiple="false"
                    ></misa-combobox-multiple>
                  </div>
                  <div class="col-md-quater" style="position: relative">
                    <label>Số ngày được nợ</label>
                    <misa-input></misa-input>
                  </div>
                  <div class="col-md-quater" style="position: relative">
                    <label>Số nợ tối đa</label>
                    <misa-input></misa-input>
                  </div>
                </div>
              </div>
            </div>
            <div class="content-select-layout-row">
              <div class="full-content">
                <div class="full-content-quarter">
                  <div
                    class="col-md-quater"
                    style="position: relative"
                    id="multiple-cbb-no-icon"
                  >
                    <label>Tài khoản công nợ phải thu</label>
                    <misa-form-combobox
                      :isBorderRedFormCBB="isBorderRed"
                      :entityFormCBB="provider"
                      :errorsFormCBB="errors"
                      :listEntitySearchFormCBB="accounts"
                      :propName="'AccountName'"
                      :valueInput="valueInputFormCBB"
                      :propCode="'AccountNumber'"
                      :propBorderRed="'ParentId'"
                      :textColFirst="
                        this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                          .textProperty.accountNumber
                      "
                      :textColSecond="
                        this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                          .textProperty.accountName
                      "
                    ></misa-form-combobox>
                  </div>
                  <div
                    class="col-md-quater"
                    style="position: relative"
                    id="multiple-cbb-no-icon"
                  >
                    <label>Tài khoản công nợ phải trả</label>
                    <misa-form-combobox
                      :isBorderRedFormCBB="isBorderRed"
                      :entityFormCBB="provider"
                      :errorsFormCBB="errors"
                      :listEntitySearchFormCBB="accounts"
                      :propName="'AccountName'"
                      :valueInput="valueInputFormCBB"
                      :propCode="'AccountNumber'"
                      :propBorderRed="'ParentId'"
                      :textColFirst="
                        this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                          .textProperty.accountNumber
                      "
                      :textColSecond="
                        this.$_MISAResource[this.$_LANG_CODE].ACCOUNT.form
                          .textProperty.accountName
                      "
                    ></misa-form-combobox>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="content-select-layout" v-if="selectLayout.bankAccount">
            <table class="table-input">
              <thead class="table-input-title">
                <tr>
                  <th class="table-input-col-1">Số tài khoản</th>
                  <th class="table-input-col-2">Tên ngân hàng</th>
                  <th class="table-input-col-3">Chi nhánh</th>
                  <th class="table-input-col-4">Tỉnh/TP của ngân hàng</th>
                  <th class="table-input-col-5"></th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td class="table-input-col-1">
                    <misa-input ref="AccountNumber"></misa-input>
                  </td>
                  <td class="table-input-col-2"><misa-input></misa-input></td>
                  <td class="table-input-col-3"><misa-input></misa-input></td>
                  <td class="table-input-col-4"><misa-input></misa-input></td>
                  <td class="table-input-col-5">
                    <div class="delete-row-table-input">
                      <div class="delete-icon"></div>
                    </div>
                  </td>
                </tr>
              </tbody>
              <tfoot>
                <td colspan="5">
                  <misa-button-extra
                    :textButtonExtra="'Thêm dòng'"
                  ></misa-button-extra>
                  <misa-button-extra
                    :textButtonExtra="'Xóa hết dòng'"
                  ></misa-button-extra>
                </td>
              </tfoot>
            </table>
          </div>
          <div
            class="content-select-layout"
            id="address-Other"
            v-if="selectLayout.addressOther"
          >
            <div class="content-select-layout-half">
              <div class="half-content">
                <div class="col-md-l cbb-has-label" style="position: relative">
                  <label>Vị trí địa lý</label>
                  <misa-combobox
                    :isBorderRedCBB="isBorderRed"
                    :entityCBB="provider"
                    :errorsCBB="errors"
                    :listEntitySearchCBB="listNatureSearch"
                    :propName="'Nature'"
                    :propId="'NatureId'"
                    :placeholderInputCBB="'Quốc gia'"
                  ></misa-combobox>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-l cbb-has-label" style="position: relative">
                  <label class="label-hide-text">hide</label>
                  <misa-combobox
                    :isBorderRedCBB="isBorderRed"
                    :entityCBB="provider"
                    :errorsCBB="errors"
                    :listEntitySearchCBB="listNatureSearch"
                    :propName="'Nature'"
                    :propId="'NatureId'"
                    :placeholderInputCBB="'Tỉnh/Thành phố'"
                  ></misa-combobox>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-l cbb-no-label" style="position: relative">
                  <misa-combobox
                    :isBorderRedCBB="isBorderRed"
                    :entityCBB="provider"
                    :errorsCBB="errors"
                    :listEntitySearchCBB="listNatureSearch"
                    :propName="'Nature'"
                    :propId="'NatureId'"
                    :placeholderInputCBB="'Quận/Huyện'"
                  ></misa-combobox>
                </div>
              </div>
              <div class="half-content">
                <div class="col-md-l cbb-no-label" style="position: relative">
                  <misa-combobox
                    :isBorderRedCBB="isBorderRed"
                    :entityCBB="provider"
                    :errorsCBB="errors"
                    :listEntitySearchCBB="listNatureSearch"
                    :propName="'Nature'"
                    :propId="'NatureId'"
                    :placeholderInputCBB="'Xã/Phường'"
                  ></misa-combobox>
                </div>
              </div>
            </div>
            <div class="content-select-layout-half">
              <table class="table-input" id="table-input-address-other">
                <thead class="table-input-title">
                  <tr>
                    <th class="table-input-col-4" colspan="2">
                      Địa chỉ giao hàng
                    </th>
                    <th>
                      <input type="checkbox" />
                    </th>
                    <th style="font-weight: 400">Giống địa chỉ nhà cung cấp</th>
                    <th class="table-input-col-5"></th>
                  </tr>
                </thead>
                <tbody>
                  <tr class="table-input-has-data">
                    <td class="table-input-col-4" colspan="4">
                      <misa-input></misa-input>
                    </td>
                    <td class="table-input-col-5">
                      <div class="delete-row-table-input">
                        <div class="delete-icon"></div>
                      </div>
                    </td>
                  </tr>
                </tbody>
                <tfoot>
                  <td colspan="4">
                    <misa-button-extra
                      :textButtonExtra="'Thêm dòng'"
                    ></misa-button-extra>
                    <misa-button-extra
                      :textButtonExtra="'Xóa hết dòng'"
                    ></misa-button-extra>
                  </td>
                </tfoot>
              </table>
            </div>
          </div>
          <div
            class="content-select-layout"
            v-if="selectLayout.note"
            id="content-select-layout-note"
          >
            <label>Ghi chú</label>
            <misa-input-textarea
              v-model="provider.Note"
              ref="Note"
              :class="{ 'border-red': isBorderRed.Note }"
              @input="setIsBorderRed('Note')"
              @mouseenter="isHovering.Note = true"
              @mouseleave="isHovering.Note = false"
            ></misa-input-textarea>
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
    <!-- dialog employee input data not blank -->
    <misa-dialog-data-not-null
      v-if="isShowDialogDataNotNull"
      :valueNotNull="dataNotNull"
      :title="this.$_MISAResource[this.$_LANG_CODE].DIALOG.TITLE.DATA_INVALID"
    ></misa-dialog-data-not-null>
    <!-- dialog employee id Exist -->
    <misa-dialog-data-exist
      v-if="isShowDialogCodeExist"
      :textProp="this.$_MISAResource[this.$_LANG_CODE].DIALOG.CONTENT.EXIST_PRE"
      :textEntityCodeExist="contentProviderCodeExist"
    ></misa-dialog-data-exist>
    <!-- dialog employee save and close -->
    <misa-dialog-data-change
      v-if="isShowDialogDataChange"
    ></misa-dialog-data-change>
  </div>
</template>

<script>
import providerService from "@/services/provider.js";
import helperCommon from "@/scripts/helper.js";

export default {
  name: "ProviderDetail",

  props: ["providerSelected", "statusFormMode"],

  created() {
    this.loadData();

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
      this.btnCloseDialogCodeExist();
    });

    this.$_MISAEmitter.on("closeDialogDataError", () => {
      this.onCloseDialogSaveAndAdd();
    });
  },

  mounted() {
    // focus vào ô đầu tiên khi mở form chi tiết
    this.focusCode();
    // Đăng kí các sự kiện
    this.$refs.FormDetailProvider.addEventListener(
      "keydown",
      this.handleKeyDown
    );
  },

  data() {
    return {
      // Khai báo mảng lưu các thuộc tính cần validate theo thứ tự, phục vụ cho việc focus, hiển thị lỗi theo thứ tự
      providerProperty: [
        "ProviderCode",
        "ProviderName",
        "TaxCode",
        "Address",
        "PhoneNumber",
        "Website",
        "Note",
      ],
      // Khai báo đối tượng provider
      provider: {},
      // Khai báo trạng thái hiển thị của dialog cảnh báo dữ liệu k được để trống
      isShowDialogDataNotNull: false,
      // Khai báo biến xác định nội dung trường nào k được để trống
      dataNotNull: [],
      // Khai báo trạng thái hiển thị của dialog cảnh báo mã nhân viên đã tồn tại
      isShowDialogCodeExist: false,
      // Khai báo biến xác định thông tin của mã nhân viên đã tồn tại
      contentProviderCodeExist: "",
      // Khai báo biến quy định trang thái hiển thị dialog dữ liệu đã bị thay đổi
      isShowDialogDataChange: false,
      // Khai báo biến xác định border red
      isBorderRed: {},
      // Khai báo biên lưu mã nhân viên tự động sinh ra
      newProviderCode: null,
      // Khai báo biến chứa danh sách đối tượng lỗi
      errors: {},
      // Khai báo biến chứa danh sách các ô input khi hover
      isHovering: {},
      // Khai báo danh sách đơn vị tìm kiếm
      listNatureSearch: [
        { Id: 1, Nature: "Dư nợ" },
        { Id: 2, Nature: "Dư có" },
        { Id: 3, Nature: "Lưỡng tính" },
        { Id: 4, Nature: "Không có số dư" },
      ],

      // Biến quy định layout nào đang được chọn
      selectLayout: {
        infoContact: true,
        termPayment: false,
        bankAccount: false,
        addressOther: false,
        note: false,
      },
    };
  },

  methods: {
    /**
     * Mô tả: Hàm xử lí chọn layout tương ứng
     * created by : BNTIEN
     * created date: 25-07-2023 11:32:35
     */
    handleSelectLayout(layout) {
      for (const key in this.selectLayout) {
        if (Object.hasOwnProperty.call(this.selectLayout, key)) {
          if (key == layout) {
            this.selectLayout[key] = true;
            if (key == "bankAccount") {
              this.$nextTick(() => {
                this.$refs.AccountNumber.focus();
              });
            }
          } else {
            this.selectLayout[key] = false;
          }
        }
      }
    },

    /**
     * Mô tả: Lấy nhân viên có giá trị lớn nhất trong hệ thống
     * created by : BNTIEN
     * created date: 24-06-2023 09:57:13
     */
    async getNewCode() {
      try {
        let maxCode = await providerService.getCodeMax();
        this.newProviderCode = maxCode.data;
      } catch {
        return;
      }
    },

    /**
     * Mô tả: gọi api lấy dữ liệu
     * created by : BNTIEN
     * created date: 30-05-2023 14:57:33
     */
    async loadData() {
      try {
        await this.getNewCode();
        // Nếu form ở trạng thái thêm mới
        // Chuyển đối tượng sang chuỗi json
        let res = JSON.stringify(this.providerSelected);
        // Chuyển đổi chuỗi json thành đối tượng provider
        this.provider = JSON.parse(res);
        if (this.statusFormMode !== this.$_MISAEnum.FORM_MODE.Edit) {
          // Sinh mã tự động
          this.provider.ProviderCode = this.newProviderCode;
        }
        this.provider.IsPersonal = false;
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Hàm focus vào ô input mã nhân viên
     * created by : BNTIEN
     * created date: 27-06-2023 01:53:48
     */
    focusCode() {
      this.$refs.TaxCode.focus();
    },

    /**
     * Mô tả: Hàm kiểm tra xem provider có thay đổi sau khi mở form detail không
     * created by : BNTIEN
     * created date: 30-06-2023 00:21:22
     */
    hasDataChanged() {
      return (
        JSON.stringify(this.providerSelected) !== JSON.stringify(this.provider)
      );
    },
    /**
     * Mô tả: Hàm sử lí sự kiện khi click vào icon close
     * created by : BNTIEN
     * created date: 29-05-2023 07:54:28
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
     * Mô tả: Hàm set các lỗi nhập liệu phía fontend
     * created by : BNTIEN
     * created date: 11-07-2023 16:36:05
     */
    setError(key) {
      try {
        this.errors[key] =
          this.$_MISAResource[this.$_LANG_CODE].PROVIDER.form.validateNotNull[
            key
          ];
        this.isBorderRed[key] = true;
        this.dataNotNull.push(
          this.$_MISAResource[this.$_LANG_CODE].PROVIDER.form.validateNotNull[
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
     * created date: 11-07-2023 16:36:05
     */
    setErrorMaxLength(key) {
      try {
        this.errors[key] =
          this.$_MISAResource[this.$_LANG_CODE].PROVIDER.form.maxLength[
            key
          ].Warning;
        this.isBorderRed[key] = true;
        this.dataNotNull.push(
          this.$_MISAResource[this.$_LANG_CODE].PROVIDER.form.maxLength[key]
            .Warning
        );
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Validate lỗi nhập liệu phía fontend
     * created by : BNTIEN
     * created date: 11-07-2023 10:07:22
     */
    validateProvider() {
      try {
        for (const refInput of this.providerProperty) {
          switch (refInput) {
            case "ProviderCode":
            case "ProviderName":
              if (helperCommon.isEmptyInput(this.provider[refInput])) {
                this.setError(refInput);
              } else if (
                helperCommon.isMaxLengthInput(
                  this.provider[refInput],
                  this.$_MISAResource[this.$_LANG_CODE].PROVIDER.form.maxLength[
                    refInput
                  ].Limit
                )
              ) {
                this.setErrorMaxLength(refInput);
              }
              break;
            default:
              if (this.provider[refInput]) {
                if (
                  helperCommon.isMaxLengthInput(
                    this.provider[refInput],
                    this.$_MISAResource[this.$_LANG_CODE].PROVIDER.form
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
     * Mô tả: Hàm xử lí lỗi nhập liệu người dùng khi backend trả về lỗi
     * created by : BNTIEN
     * created date: 29-06-2023 07:07:16
     */
    handleErrorInputProvider(errors, providerProperty) {
      const responseHandle = helperCommon.handleErrorInput(
        errors,
        providerProperty
      );
      this.errors = responseHandle.error;
      this.isBorderRed = responseHandle.isBorderRed;
      this.dataNotNull = responseHandle.dataNotNull;
      if (this.dataNotNull.length > 0) {
        this.isShowDialogDataNotNull = true;
      }
    },
    /**
     * Mô tả: Hàm kiểm tra xem mã nhân viên đã tồn tại trong database hay chưa
     * created by : BNTIEN
     * created date: 29-06-2023 23:46:11
     */
    async checkProviderExists() {
      try {
        const res = await providerService.getByCode(this.provider.ProviderCode);
        return res.data;
      } catch {
        return null;
      }
    },
    /**
     * Mô tả: Hàm xử lí khi mã nhân viên đã tồn tại trong hệ thống
     * created by : BNTIEN
     * created date: 30-06-2023 00:30:22
     */
    handleProviderExisted(providerExisted) {
      this.isShowDialogCodeExist = true;
      this.isBorderRed.ProviderCode = true;
      this.errors["ProviderCode"] = `Mã nhà cung cấp
       ${providerExisted.ProviderCode} ${
        this.$_MISAResource[this.$_LANG_CODE].DIALOG.CONTENT.EXIST_DETAIL_END
      }`;
      this.contentProviderCodeExist = providerExisted.ProviderCode;
    },
    /**
     * Mô tả: Hàm xử lí sự kiện khi người dùng bấm vào nút cất trên form chi tiết
     * created by : BNTIEN
     * created date: 29-05-2023 07:55:05
     */
    async btnSave() {
      if (this.statusFormMode === this.$_MISAEnum.FORM_MODE.Add) {
        this.validateProvider();
        if (this.dataNotNull.length > 0) {
          this.isShowDialogDataNotNull = true;
        } else {
          try {
            // Kiểm tra xem mã nhân viên đã tồn tại trong database chưa, nếu đã tồn tại thì thông báo cho người dùng
            let providerByCode = await this.checkProviderExists();
            if (!providerByCode) {
              // Nếu mã nhân viên chưa tồn tại trong hệ thống
              const res = await providerService.create(this.provider);
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
              this.handleProviderExisted(providerByCode);
            }
          } catch (error) {
            this.handleErrorInputProvider(error, this.providerProperty);
          }
        }
      } else {
        // Nếu form ở trạng thái sửa
        // Kiểm tra xem dữ liệu có thay đổi hay k (Trường hợp đã thay đổi)
        if (this.hasDataChanged()) {
          this.validateProvider();
          if (this.dataNotNull.length > 0) {
            this.isShowDialogDataNotNull = true;
          } else {
            try {
              // Kiểm tra xem mã nhân viên đã tồn tại trong database chưa, nếu đã tồn tại thì thông báo cho người dùng
              let providerByCode = await this.checkProviderExists();
              // Nếu mã nhân viên chưa tồn tại trong hệ thống hoặc tồn tại nhưng trùng với nhân viên đang sửa
              if (
                !providerByCode ||
                providerByCode.ProviderCode ===
                  this.providerSelected.ProviderCode
              ) {
                const res = await providerService.update(
                  this.providerSelected.ProviderId,
                  this.provider
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
                this.handleProviderExisted(providerByCode);
              }
            } catch (error) {
              this.handleErrorInputProvider(error, this.providerProperty);
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
     * created date: 29-05-2023 07:55:23
     */
    async btnSaveAndAdd() {
      // Nếu form ở trạng thái thêm mới
      if (this.statusFormMode === this.$_MISAEnum.FORM_MODE.Add) {
        this.validateProvider();
        if (this.dataNotNull.length > 0) {
          this.isShowDialogDataNotNull = true;
        } else {
          try {
            // Kiểm tra xem mã nhân viên đã tồn tại trong database chưa, nếu đã tồn tại thì thông báo cho người dùng
            let providerByCode = await this.checkProviderExists();
            if (!providerByCode) {
              // Nếu mã nhân viên chưa tồn tại trong hệ thống
              const res = await providerService.create(this.provider);
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
                this.provider = {};
                this.isBorderRed = {};
                this.$_MISAEmitter.emit("refreshDataTable");
                await this.getNewCode();
                this.provider.ProviderCode = this.newProviderCode;
                this.focusCode();
              }
            } else {
              // Nếu mã nhân viên đã tồn tại trong hệ thống
              this.handleProviderExisted(providerByCode);
            }
          } catch (error) {
            this.handleErrorInputProvider(error, this.providerProperty);
          }
        }
        // Nếu form ở trạng thái sửa
      } else {
        // Kiểm tra xem dữ liệu có thay đổi hay k
        if (this.hasDataChanged()) {
          this.validateProvider();
          if (this.dataNotNull.length > 0) {
            this.isShowDialogDataNotNull = true;
          } else {
            try {
              // Kiểm tra xem mã nhân viên đã tồn tại trong database chưa, nếu đã tồn tại thì thông báo cho người dùng
              let providerByCode = await this.checkProviderExists();
              // Nếu mã nhân viên chưa tồn tại trong hệ thống hoặc tồn tại trùng với nhân viên đang sửa
              if (
                !providerByCode ||
                providerByCode.ProviderCode ===
                  this.providerSelected.ProviderCode
              ) {
                const res = await providerService.update(
                  this.providerSelected.ProviderId,
                  this.provider
                );
                this.provider = {};
                this.$_MISAEmitter.emit("setFormModeAdd");
                await this.getNewCode();
                this.provider.ProviderCode = this.newProviderCode;
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
                this.handleProviderExisted(providerByCode);
              }
            } catch (error) {
              this.handleErrorInputProvider(error, this.providerProperty);
            }
          }
        } else {
          this.provider = {};
          this.$_MISAEmitter.emit("setFormModeAdd");
          this.focusCode();
        }
      }
    },
    /**
     * Mô tả: Hàm đóng dialog cảnh báo dữ liệu k được để trống và focus vào các ô trống
     * created by : BNTIEN
     * created date: 29-05-2023 07:55:59
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

      for (const prop of this.providerProperty) {
        if (listPropError.includes(prop)) {
          // đợi DOM cập nhật trước khi thực thi focus
          this.$nextTick(() => {
            this.$refs[prop].focus();
          });
          return;
        }
      }
    },

    /**
     * Mô tả: Hàm bỏ border red khi dữ liệu thay đổi
     * created by : BNTIEN
     * created date: 29-06-2023 22:03:38
     */
    setIsBorderRed(prop) {
      if (prop in this.isBorderRed) {
        this.isBorderRed[prop] = false;
      }
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi click vào nút hủy trong form chi tiết
     * created by : BNTIEN
     * created date: 29-05-2023 07:56:20
     */
    btnCancel() {
      this.$emit("closeFormDetail");
    },
    /**
     * Mô tả: Hàm xử lí sự kiện đóng dialog cảnh báo mã nhân viên đã tồn tại
     * created by : BNTIEN
     * created date: 29-05-2023 08:28:19
     */
    btnCloseDialogCodeExist() {
      this.isShowDialogCodeExist = false;
      this.$refs.ProviderCode.focus();
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi bấm vào button hủy trong dialog dữ liệu đã bị thay đổi
     * created by : BNTIEN
     * created date: 30-05-2023 23:40:13
     */
    onCancelDialogDataChange() {
      this.isShowDialogDataChange = false;
      this.focusCode();
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi bấm vào button không trong dialog dữ liệu đã bị thay đổi
     * created by : BNTIEN
     * created date: 30-05-2023 23:42:10
     */
    onNoDialogDataChange() {
      this.$emit("closeFormDetail");
    },

    /**
     * Mô tả: Hàm xử lí sự kiện khi bấm vào button có trong dialog dữ liệu đã bị thay đổi
     * created by : BNTIEN
     * created date: 30-05-2023 23:43:38
     */
    async onYesDialogDataChange() {
      this.isShowDialogDataChange = false;
      await this.btnSave();
    },

    /**
     * Mô tả: Hàm reset tabindex về ô input mã nhân viên khi tab nhảy đến icon close
     * created by : BNTIEN
     * created date: 01-06-2023 14:24:19
     */
    resetTab() {
      this.focusCode();
    },

    /**
     * Mô tả: Xử lí sự kiện click vào radio tổ chức
     * created by : BNTIEN
     * created date: 28-07-2023 13:42:36
     */
    handleClickInstitute() {
      this.provider.IsPersonal = false;
    },

    /**
     * Mô tả: Xử lí sự kiện click vào radio các nhân
     * created by : BNTIEN
     * created date: 28-07-2023 13:43:49
     */
    handleClickPersonal() {
      this.provider.IsPersonal = true;
    },

    /**
     * Mô tả: Xử lí toggle check box khách hàng
     * created by : BNTIEN
     * created date: 28-07-2023 13:53:09
     */
    toggleCheckboxCustomer() {
      this.provider.IsCustomer = !this.provider.IsCustomer;
    },
  },

  beforeUnmount() {
    this.$_MISAEmitter.off("cancelDialogDataChange");
    this.$_MISAEmitter.off("noDialogDataChange");
    this.$_MISAEmitter.off("yesDialogDataChange");
    this.$_MISAEmitter.off("closeDialogCodeExist");
    this.$_MISAEmitter.off("closeDialogDataError");
    this.$refs.FormDetailProvider.removeEventListener(
      "keydown",
      this.handleKeyDown
    );
  },
};
</script>

<style scoped>
@import url(./ProviderDetail.css);

input {
  height: 26px;
}

.active-layout {
  background-color: rgb(159, 207, 225);
  height: 30px;
}

#detail-info-provider input[type="checkbox"] {
  height: 16px;
}

#detail-info-provider input[type="radio"] {
  height: 20px;
}

#detail-info-provider .table-input-has-data td:first-child {
  border-bottom: 1px solid var(--color-border-default);
}

.border-red {
  border: 1px solid red;
}
</style>
