<template>
  <div class="content-title">
    <h1>{{ this.$_MISAResource[this.$_LANG_CODE].PROVIDER.title }}</h1>
    <div class="all-category">
      <div class="prev-icon icon-tb"></div>
      <router-link to="/category">
        <div class="all-category-text">
          {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ALL_CATEGORY }}
        </div>
      </router-link>
    </div>
  </div>
  <div class="content-info-money">
    <div class="info-money-item">
      <div
        class="info-money-item-left"
        style="background-color: rgb(237, 118, 81)"
      ></div>
      <div class="info-money-item-right">
        <div class="money">
          <div class="format-money">1.336.000.000</div>
          <div class="icon-l filter-icon"></div>
        </div>
        <div class="content-money">
          <span>{{
            this.$_MISAResource[this.$_LANG_CODE].PROVIDER.overdue
          }}</span>
        </div>
      </div>
    </div>
    <div class="info-money-item">
      <div class="info-money-item-left" style="background-color: #858383"></div>
      <div class="info-money-item-right">
        <div class="money">
          <div class="format-money">13.135.323.869</div>
          <div class="icon-l filter-icon"></div>
        </div>
        <div class="content-money">
          <span>{{
            this.$_MISAResource[this.$_LANG_CODE].PROVIDER.totalLiabiliti
          }}</span>
        </div>
      </div>
    </div>
    <div class="info-money-item">
      <div
        class="info-money-item-left"
        style="background-color: var(--color-btn-default)"
      ></div>
      <div class="info-money-item-right">
        <div class="money">
          <div class="format-money">0</div>
        </div>
        <div class="content-money">
          <span>{{
            this.$_MISAResource[this.$_LANG_CODE].PROVIDER.recentPayment
          }}</span>
          <span class="content-money-last-child">{{
            this.$_MISAResource[this.$_LANG_CODE].PROVIDER.figureUpto
          }}</span>
        </div>
      </div>
    </div>
  </div>
  <button class="refresh-money">
    <div class="icon-l refresh-icon" style="scale: 0.8 0.8"></div>
  </button>
  <div id="content-main-body-provider" class="content-main-body">
    <div class="content-action">
      <div class="content-action-left">
        <div class="container-direction-arrow">
          <div class="icon-l direction-arrow"></div>
        </div>
        <button
          :disabled="isDisableExcuteBatch"
          class="delete-multiple"
          @click="onShowExcuteBatch"
          :class="{ 'no-disable': !isDisableExcuteBatch }"
          ref="DeleteMulti"
        >
          <div class="select-function-delete">
            <span>{{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.EXCUTE_BATCH
            }}</span>
            <div class="delete-multiple-icon">
              <div class="function-icon-disable"></div>
            </div>
          </div>
          <div class="menu-delete" v-show="isShowMenuExcuteBatch">
            <div class="menu-item-delete" @click="onShowDialogDeleteMulti">
              {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.DELETE }}
            </div>
          </div>
        </button>
        <button class="delete-multiple filter-provider" :class="'no-disable'">
          <div class="select-function-delete">
            <span>Lọc</span>
            <div class="delete-multiple-icon">
              <div class="function-icon-disable"></div>
            </div>
          </div>
          <div class="menu-delete" v-show="false">
            <div class="menu-item-delete">
              {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.DELETE }}
            </div>
          </div>
        </button>
      </div>
      <div class="search-entity">
        <input
          type="search"
          :placeholder="
            this.$_MISAResource[this.$_LANG_CODE].PROVIDER.placeholderSearch
          "
          v-model="textSearch"
          @keydown.enter="onSearchProvider"
          @input="autoSearch"
        />
        <div class="search-icon icon-tb" @click="onSearchProvider"></div>
      </div>
      <div
        @click="refreshData"
        class="refresh-icon icon-tb"
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.REFRESH"
      ></div>
      <div
        @click="exportData"
        class="excel-icon icon-tb"
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.EXCEL"
      ></div>
      <div
        class="setting-icon icon-tb"
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.SETTING_MAIN"
      ></div>
      <div class="utilities" @click="isShowUtilities = !isShowUtilities">
        <div class="utilities-text">
          {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.UTILITIES }}
        </div>
        <div class="function-icon-disable"></div>
        <div class="utilities-synchronized" v-if="isShowUtilities">
          {{
            this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
              .UTILITIES_SYNCHRONIZED
          }}
        </div>
      </div>
      <div class="insert-data">
        <misa-button-default
          :textButtonDefault="
            this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.ADD_EMPLOYEE
          "
          @click="btnOpenFormDetail"
        ></misa-button-default>
        <misa-button-icon></misa-button-icon>
      </div>
    </div>
    <div id="list-provider" class="list-entity">
      <form action="">
        <table id="tbProviderList">
          <thead>
            <tr>
              <th type="checkbox" class="entity-border-left">
                <div class="th-checkbox">
                  <input
                    class="checkbox-select-row"
                    type="checkbox"
                    @click="checkAllSelect"
                    :checked="isCheckAll"
                  />
                </div>
              </th>
              <th>
                {{
                  this.$_MISAResource[this.$_LANG_CODE].PROVIDER.colTableName
                    .providerCode
                }}
              </th>
              <th>
                {{
                  this.$_MISAResource[this.$_LANG_CODE].PROVIDER.colTableName
                    .providerName
                }}
              </th>
              <th>
                {{
                  this.$_MISAResource[this.$_LANG_CODE].PROVIDER.colTableName
                    .address
                }}
              </th>
              <th>
                {{
                  this.$_MISAResource[this.$_LANG_CODE].PROVIDER.colTableName
                    .amountOwed
                }}
              </th>
              <th>
                {{
                  this.$_MISAResource[this.$_LANG_CODE].PROVIDER.colTableName
                    .rawCode
                }}
              </th>
              <th>
                {{
                  this.$_MISAResource[this.$_LANG_CODE].PROVIDER.colTableName
                    .phoneNumber
                }}
              </th>
              <th>
                {{
                  this.$_MISAResource[this.$_LANG_CODE].PROVIDER.colTableName
                    .branch
                }}
              </th>
              <th
                type="feat"
                class="text-center entity-border-right e-birthday"
              >
                {{
                  this.$_MISAResource[this.$_LANG_CODE].EMPLOYEE_COL_NAME
                    .FEATURE
                }}
              </th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-show="dataTable.TotalRecord"
              v-for="item in dataTable.Data"
              :key="item.ProviderId"
              @dblclick="onUpdateFormDetail(item)"
              :class="{ checkedRow: checkRow().includes(item.ProviderId) }"
            >
              <td class="entity-border-left" @dblclick.stop>
                <div class="th-checkbox">
                  <input
                    class="checkbox-select-row"
                    type="checkbox"
                    @click="checkRow(item.ProviderId)"
                    :checked="checkRow().includes(item.ProviderId)"
                  />
                </div>
              </td>
              <td>{{ item.ProviderCode }}</td>
              <td>{{ item.ProviderName }}</td>
              <td>{{ item.Address }}</td>
              <td></td>
              <td>{{ item.TaxCode }}</td>
              <td>{{ item.PhoneNumber }}</td>
              <td></td>
              <td
                class="text-center entity-border-right e-birthday function-table"
                @dblclick.stop
              >
                <span @click="onUpdateFormDetail(item)">
                  {{
                    this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.UPDATE
                  }}
                </span>
                <div
                  class="function-table-content"
                  @click="onOpenFeatureMenu($event, item)"
                >
                  <div class="function-icon-table function-icon-select"></div>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </form>
      <teleport to="#app">
        <div
          class="menu-function-select"
          v-show="isShowColFeature"
          :style="{
            left: `${this.positionFeatureMenu.left}px`,
            top: `${this.positionFeatureMenu.top}px`,
          }"
        >
          <div @click="onDupliCateProvider">
            {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.DUPLICATE }}
          </div>
          <div @click="onDeleteProvider">
            {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.DELETE }}
          </div>
          <div>
            {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.STOP_USING }}
          </div>
        </div>
      </teleport>
      <img
        v-show="isShowLoadding && this.dataTable.TotalRecord !== undefined"
        class="loading"
        :class="{ 'loadding-form-detail': isShowFormDetail }"
        src="../../../assets/img/loading.svg"
        alt="loading"
      />
      <div
        v-if="!this.dataTable.TotalRecord || this.dataTable.TotalRecord === 0"
        class="no-data"
      >
        {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.NO_DATA }}
      </div>
    </div>
    <div class="pagination">
      <p>
        {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.TOTAL }}:
        <b>{{ this.dataTable.TotalRecord ? this.dataTable.TotalRecord : 0 }}</b>
        {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.RECORD }}
      </p>
      <div class="pagination-detail">
        <div
          class="pagination-detail-pagesize"
          :class="{ 'active-record': isShowPaging }"
          ref="PagingMenu"
        >
          <div
            id="pagination-detail-pagesize-content"
            class="pagination-detail-pagesize-content"
          >
            {{ selectedRecord }}
            {{
              this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.RECORD_ON_PAGE
            }}
          </div>
          <div
            id="menu-paging-select"
            class="menu-paging-select"
            @click="onShowSelectPaging"
          >
            <div
              class="function-icon"
              :class="{ 'rotate-function-icon': isShowPaging }"
            ></div>
            <ul id="menu-paging" class="menu-paging" v-show="isShowPaging">
              <li
                class="menu-paging-record"
                v-for="(record, index) in recordOptions"
                :key="index"
                @click="onSelectedRecord(record, index)"
                :class="{ 'active-record-item': indexSelectedRecord === index }"
              >
                {{ record }}
                {{
                  this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
                    .RECORD_ON_PAGE
                }}
              </li>
            </ul>
          </div>
        </div>
        <div class="pagination-page-number">
          <ul class="page-number">
            <button
              @click="
                goToPage(
                  this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.PAGE
                    .PREVIOUS
                )
              "
              :disabled="isFirstPage"
            >
              {{
                this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.PAGING_PRE
              }}
            </button>
            <button
              v-for="pageNumber in this.visiblePageNumbers"
              :key="pageNumber"
              @click="goToPage(pageNumber)"
              :class="{ 'active-page': pageNumber === this.currentPage }"
            >
              {{ pageNumber }}
            </button>
            <button
              @click="
                goToPage(
                  this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.PAGE.NEXT
                )
              "
              :disabled="isLastPage"
            >
              {{
                this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.PAGING_NEXT
              }}
            </button>
          </ul>
        </div>
      </div>
    </div>
    <!-- provider detail -->
    <ProviderDetail
      v-if="isShowFormDetail"
      @closeFormDetail="onCloseFormDetail"
      :providerSelected="providerUpdate"
      :statusFormMode="isStatusFormMode"
    ></ProviderDetail>
    <div
      v-if="isOverlay"
      id="container-overlay"
      class="container-overlay"
      @closeFormDetail="onCloseFormDetail"
    ></div>
    <!-- dialog confirm delete -->
    <misa-dialog-confirm-delete
      :isDeleteMultiple="isDeleteMultipleDialog"
      :contentDeleteMultiple="
        this.$_MISAResource[this.$_LANG_CODE].PROVIDER.confirmDelete.multiple
      "
      :contentDelete="`${
        this.$_MISAResource[this.$_LANG_CODE].PROVIDER.confirmDelete.prev
      }${providerCodeDeleteSelected}${
        this.$_MISAResource[this.$_LANG_CODE].PROVIDER.confirmDelete.end
      }`"
      v-if="isShowDialogConfirmDelete"
    ></misa-dialog-confirm-delete>
    <!-- toast message -->
    <misa-toast-success
      v-if="isShowToastMessage"
      :contentToast="contentToastSuccess"
    ></misa-toast-success>
    <a href="" ref="ExportListProvider" v-show="false"></a>
  </div>
</template>

<script>
import ProviderDetail from "@/views/provider/provider_detail/ProviderDetail.vue";
import providerService from "@/services/provider.js";

export default {
  name: "ProviderList",

  components: {
    ProviderDetail,
  },

  created() {
    // Gọi hàm lấy dữ liệu danh sách nhà cung cấp
    this.getListProvider();
    // Đăng kí các sự kiện
    this.$_MISAEmitter.on("onShowToastMessage", (data) => {
      this.contentToastSuccess = data;
      this.onShowToastMessage();
    });
    this.$_MISAEmitter.on("onShowToastMessageUpdate", (data) => {
      this.contentToastSuccess = data;
      this.onShowToastMessage();
    });
    this.$_MISAEmitter.on("setFormModeAdd", () => {
      this.setFormModeAdd();
    });
    this.$_MISAEmitter.on("refreshDataTable", async () => {
      await this.getListProvider();
    });
    this.$_MISAEmitter.on("confirmYesDeleteEntity", async () => {
      await this.btnConfirmYesDeleteProvider();
    });
    this.$_MISAEmitter.on("confirmNoDeleteEntity", () => {
      this.btnConfirmNoDeleteProvider();
    });
    this.$_MISAEmitter.on("confirmYesDeleteMultiple", async () => {
      await this.btnConfirmYesDeleteMultipleProvider();
    });
    this.$_MISAEmitter.on("closeToastMessage", () => {
      this.btnCloseToastMessage();
    });
  },

  mounted() {
    // Lắng nghe sự kiện click trên toàn bộ màn hình
    window.addEventListener("click", this.handleClickOutsidePaging);
    window.addEventListener("click", this.handleClickOutsideDeleteMulti);
    window.addEventListener("click", this.handleClickOutsideFeature);
  },

  data() {
    return {
      // Khai báo biến quy định trạng thái hiển thị của form chi tiết
      isShowFormDetail: false,
      // Khai báo biến quy định trạng thái hiển thị overlay
      isOverlay: false,
      // Khai báo biến quy định trạng thái hiển thị của các chức năng ở cột cuối của table
      isShowColFeature: false,
      // Khai báo biến quy định trạng thái hiển thị của các item select paging
      isShowPaging: false,
      // Khai báo biến kiểm tra xem form chi tiết đang ở trạng thái thêm hay sửa
      isStatusFormMode: this.$_MISAEnum.FORM_MODE.Add,
      // Khai báo trạng thái hiển thị của toast message
      isShowToastMessage: false,
      // Khai báo dữ liệu duyệt trên 1 trang table
      dataTable: [],
      // Khai báo 1 nhà cung cấp được chọn để xử lí hàm sửa
      providerUpdate: {},
      // Khai báo số bản ghi mặc định được hiển thi trên table
      selectedRecord: this.$_MISAEnum.RECORD.RECORD_DEFAULT,
      // Khai báo list số bản ghi có thể lựa chọn để hiển thị trên trang
      recordOptions: this.$_MISAEnum.RECORD.RECORD_OPTIONS,
      // Khai báo ProviderId của nhà cung cấp cần xóa
      providerIdDeleteSelected: "",
      // Khai báo ProviderCode của nhà cung cấp cần xóa
      providerCodeDeleteSelected: "",
      // Khai báo biến quy định trạng thái ẩn hiển dialog confirm delete
      isShowDialogConfirmDelete: false,
      // Khai báo biến lưu nội dung của toast message
      contentToastSuccess: "",
      // Khai báo biến lưu nội dung tìm kiếm
      textSearch: "",
      // Khai báo trang hiện tại trong phân trang
      currentPage: this.$_MISAEnum.RECORD.CURRENT_PAGE,
      // Khai báo số trang tối đa hiển thị trong phân trang
      maxVisiblePages: this.$_MISAEnum.RECORD.MAX_VISIBLE_PAGE,
      // Khai báo biến quy định trạng thái hiển thị loadding
      isShowLoadding: false,
      // Khai báo biến lưu chỉ số index được chọn trong paging
      indexSelectedRecord: this.$_MISAEnum.RECORD.INDEX_SELECTED_DEFAULT,
      // Khai báo biến quy định sau 1 khoảng thời gian mới bắt đầu tìm kiếm
      searchProviderTimeout: null,
      // Khai báo biến quy định trạng thái hiển thị của menu thực hiện hàng loạt
      isShowMenuExcuteBatch: false,
      // Khai báo biến lưu danh sách id cần xóa
      ids: [],
      // Khai báo biến kiểm tra xem dialog hiển thị hỏi xóa ít hay xóa nhiều
      isDeleteMultipleDialog: null,
      // Khai báo biến tùy chỉnh top, left cho feature menu
      positionFeatureMenu: {},
      // Khai báo biến lưu provider khi bấm vào col feature
      selectedProvider: {},
      // Khai báo biến quy định trạng thái hiển thị tiện ích
      isShowUtilities: false,
    };
  },

  computed: {
    /**
     * Mô tả: Tính tổng số trang trong phân trang
     * created by : BNTIEN
     * created date: 04-06-2023 02:49:32
     */
    totalPages() {
      return Math.ceil(this.dataTable.TotalRecord / this.selectedRecord);
    },
    /**
     * Mô tả: Nếu đang ở trang đầu thì button prev không hoạt động
     * created by : BNTIEN
     * created date: 27-06-2023 11:19:25
     */
    isFirstPage() {
      return this.currentPage === this.$_MISAEnum.RECORD.CURRENT_PAGE;
    },
    /**
     * Mô tả: Nếu đang ở trang cuối thì button next không hoạt động
     * created by : BNTIEN
     * created date: 27-06-2023 11:19:25
     */
    isLastPage() {
      if (!this.totalPages || this.totalPages === 0) {
        return true;
      }
      return this.currentPage === this.totalPages;
    },
    /**
     * Mô tả: Tính tổng số trang sẽ hiển thị
     * created by : BNTIEN
     * created date: 04-06-2023 02:49:32
     */
    visiblePageNumbers() {
      if (!this.dataTable.TotalRecord || this.dataTable.TotalRecord === 0) {
        return [];
      }

      let startPage = Math.max(
        this.currentPage - Math.floor(this.maxVisiblePages / 2),
        1
      );
      let endPage = startPage + this.maxVisiblePages - 1;
      if (endPage > this.totalPages) {
        endPage = this.totalPages;
        startPage = Math.max(endPage - this.maxVisiblePages + 1, 1);
      }

      const visiblePages = [];
      for (let i = startPage; i <= endPage; i++) {
        visiblePages.push(i);
      }

      return visiblePages;
    },
    /**
     * Mô tả: Kiểm tra xem button thực hiện hàng loạt có ở trạng thái disable hay không
     * created by : BNTIEN
     * created date: 27-06-2023 23:26:41
     */
    isDisableExcuteBatch() {
      return this.ids.length < 2;
    },
    /**
     * Mô tả: Kiểm tra list ids chứa tất cả id trong dataTable hay không
     * created by : BNTIEN
     * created date: 28-06-2023 08:41:29
     */
    isCheckAll() {
      if (!this.dataTable.Data) return false;
      if (this.dataTable.Data.length == 0) return false;
      for (let i = 0; i < this.dataTable.Data.length; i++) {
        if (!this.ids.includes(this.dataTable.Data[i].ProviderId)) {
          return false;
        }
      }
      return true;
    },
  },

  methods: {
    /**
     * Mô tả: Hàm lấy dữ liệu nhà cung cấp từ api
     * created by : BNTIEN
     * created date: 29-05-2023 07:49:20
     */
    async getListProvider() {
      try {
        this.isShowLoadding = true;
        const resfilter = await providerService.getFilter(
          this.selectedRecord,
          this.currentPage,
          ""
        );
        this.isShowLoadding = false;
        this.dataTable = resfilter.data;
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Hàm xử lí sự kiên load lại toàn bộ dữ liệu khi click vào icon refresh
     * created by : BNTIEN
     * created date: 29-05-2023 07:49:31
     */
    async refreshData() {
      this.selectedRecord = this.$_MISAEnum.RECORD.RECORD_DEFAULT;
      (this.indexSelectedRecord =
        this.$_MISAEnum.RECORD.INDEX_SELECTED_DEFAULT),
        (this.textSearch = "");
      await this.getListProvider();
    },
    /**
     * Mô tả: Hàm xử lí sự kiên mở form chi tiết khi click vào button thêm mới nhà cung cấp
     * created by : BNTIEN
     * created date: 29-05-2023 07:48:01
     */
    btnOpenFormDetail() {
      this.isShowFormDetail = true;
      this.isOverlay = true;
      this.providerUpdate.ProviderCode = "";
    },
    /**
     * Mô tả: Hàm xử lí sự kiện khi click vào nút close trong form chi tiết
     * created by : BNTIEN
     * created date: 29-05-2023 07:48:35
     */
    onCloseFormDetail() {
      this.isShowFormDetail = false;
      this.isOverlay = false;
      this.isStatusFormMode = this.$_MISAEnum.FORM_MODE.Add;
      this.providerUpdate = {};
    },
    /**
     * Mô tả: Hàm xử lí sự kiện đóng mở các menu feature ở cột cuối của table khi click vào icon drop
     * created by : BNTIEN
     * created date: 29-05-2023 07:48:54
     */
    onOpenFeatureMenu(e, provider) {
      try {
        // chặn sự liện lan ra các phần tử cha
        e.stopPropagation();
        this.selectedProvider = provider;
        this.isShowColFeature = true;
        const positionIcon = e.target.getBoundingClientRect();
        const left = positionIcon.right - 110;
        let top = 0;
        if (positionIcon.bottom > 500) {
          top = positionIcon.bottom - 100;
        } else {
          top = positionIcon.bottom + 10;
        }
        this.positionFeatureMenu = { left: left, top: top };
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Hàm xử lí sự kiện đóng mở lựa chọn số phần tử hiển thị trên 1 trang trong table
     * created by : BNTIEN
     * created date: 29-05-2023 07:49:05
     */
    onShowSelectPaging() {
      this.isShowPaging = !this.isShowPaging;
    },
    /**
     * Mô tả: Hàm xử lí cập nhật thông tin nhà cung cấp
     * created by : BNTIEN
     * created date: 29-05-2023 07:49:56
     */
    onUpdateFormDetail(provider) {
      this.providerUpdate = provider;
      this.isShowFormDetail = true;
      this.isOverlay = true;
      this.isStatusFormMode = this.$_MISAEnum.FORM_MODE.Edit;
    },
    /**
     * Mô tả: Hàm set isStatusFormMode = ADD
     * created by : BNTIEN
     * created date: 03-06-2023 15:37:14
     */
    setFormModeAdd() {
      this.isStatusFormMode = this.$_MISAEnum.FORM_MODE.Add;
    },
    /**
     * Mô tả: Hàm xử lí sự kiện click vào các item lựa chọn số bản ghi hiển thị trên table
     * created by : BNTIEN
     * created date: 29-05-2023 07:50:06
     */
    onSelectedRecord(record, index) {
      this.selectedRecord = record;
      this.indexSelectedRecord = index;
      this.currentPage = this.$_MISAEnum.RECORD.CURRENT_PAGE;
      this.updateDataTable();
    },
    /**
     * Mô tả: Hàm xử lí sự kiện khi bấm vào item xóa nhà cung cấp thì hiển thị dialog xác nhận xóa
     * created by : BNTIEN
     * created date: 29-05-2023 07:50:15
     */
    onDeleteProvider() {
      this.isShowDialogConfirmDelete = true;
      this.isDeleteMultipleDialog = false;
      this.isOverlay = true;
      this.providerIdDeleteSelected = this.selectedProvider.ProviderId;
      this.providerCodeDeleteSelected = this.selectedProvider.ProviderCode;
    },
    /**
     * Mô tả: Hàm xử lí sự kiện khi người dùng xác nhận xóa 1 nhà cung cấp
     * created by : BNTIEN
     * created date: 28-05-2023 21:09:01
     */
    async btnConfirmYesDeleteProvider() {
      try {
        this.isShowLoadding = true;
        const res = await providerService.delete(this.providerIdDeleteSelected);
        this.isShowLoadding = false;
        this.isShowDialogConfirmDelete = false;
        this.isOverlay = false;
        if (
          this.$_MISAEnum.CHECK_STATUS.isResponseStatusOk(res.status) &&
          res.data > 0
        ) {
          this.isDeleteMultipleDialog = false;
          this.contentToastSuccess =
            this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.SUCCESS_DELETE;
          this.onShowToastMessage();
          await this.getListProvider();
        }
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Hàm xử lí sự kiện khi click vào button không trong dialog xác nhận xóa
     * created by : BNTIEN
     * created date: 29-05-2023 07:51:41
     */
    btnConfirmNoDeleteProvider() {
      this.isShowDialogConfirmDelete = false;
      this.isDeleteMultipleDialog = false;
      this.isOverlay = false;
    },

    /**
     * Mô tả: Hàm xử lí sự kiện mở toast mesage
     * created by : BNTIEN
     * created date: 31-05-2023 00:42:10
     */
    onShowToastMessage() {
      this.isShowToastMessage = true;
      setTimeout(() => {
        this.isShowToastMessage = false;
      }, 3000);
    },

    /**
     * Mô tả: Hàm xử lí sự kiện đóng toast mesage
     * created by : BNTIEN
     * created date: 31-05-2023 00:42:10
     */
    btnCloseToastMessage() {
      this.isShowToastMessage = false;
    },
    /**
     * Mô tả: Hàm nhân bản 1 nhà cung cấp
     * created by : BNTIEN
     * created date: 28-06-2023 13:59:30
     */
    onDupliCateProvider() {
      try {
        this.providerUpdate = this.selectedProvider;
        this.isShowFormDetail = true;
        this.isOverlay = true;
        this.isStatusFormMode = this.$_MISAEnum.FORM_MODE.Add;
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Hàm tìm kiếm nhà cung cấp theo mã hoặc tên
     * created by : BNTIEN
     * created date: 04-06-2023 00:20:21
     */
    async onSearchProvider() {
      try {
        this.currentPage = this.$_MISAEnum.RECORD.CURRENT_PAGE;
        if (!this.textSearch.trim()) {
          this.textSearch = "";
        }
        this.isShowLoadding = true;
        const filteredProviders = await providerService.getFilter(
          this.selectedRecord,
          this.currentPage,
          this.textSearch.trim()
        );
        this.isShowLoadding = false;
        this.dataTable = filteredProviders.data;
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Tự động tìm kiếm sau 1 khoảng thời gian người dùng không nhập dữ liệu
     * created by : BNTIEN
     * created date: 27-06-2023 11:44:30
     */
    async autoSearch() {
      try {
        clearTimeout(this.searchProviderTimeout);
        this.searchProviderTimeout = setTimeout(async () => {
          await this.onSearchProvider();
        }, 500);
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Cập nhật danh sách dữ liệu hiển thị dựa trên currentPage và pageSize
     * created by : BNTIEN
     * created date: 04-06-2023 01:49:06
     */
    async updateDataTable() {
      try {
        if (!this.textSearch.trim()) {
          this.textSearch = "";
        }
        this.isShowLoadding = true;
        const resfilter = await providerService.getFilter(
          this.selectedRecord,
          this.currentPage,
          this.textSearch.trim()
        );
        this.isShowLoadding = false;
        this.dataTable = resfilter.data;
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Di chuyển giữa các trang trong phân trang
     * created by : BNTIEN
     * created date: 04-06-2023 01:49:32
     */
    async goToPage(p) {
      let newPage;
      if (
        p ===
          this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.PAGE.PREVIOUS &&
        this.currentPage > 1
      ) {
        newPage = this.currentPage - 1;
      } else if (
        p === this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.PAGE.NEXT &&
        this.currentPage < this.totalPages
      ) {
        newPage = this.currentPage + 1;
      } else if (
        typeof p ===
          this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.PAGE.NUMBER &&
        p >= 1 &&
        p <= this.totalPages
      ) {
        newPage = p;
      }

      if (newPage !== undefined && newPage !== this.currentPage) {
        this.currentPage = newPage;
        await this.updateDataTable();
      }
    },
    /**
     * Mô tả: xử lí sự kiện khi người dùng click ra ngoài select paging
     * created by : BNTIEN
     * created date: 08-06-2023 04:50:25
     */
    handleClickOutsidePaging(event) {
      if (!this.$refs.PagingMenu.contains(event.target)) {
        this.isShowPaging = false;
      }
    },

    /**
     * Mô tả: xử lí sự kiện click ra ngoài menu thực hiện hàng loạt
     * created by : BNTIEN
     * created date: 30-06-2023 21:53:38
     */
    handleClickOutsideDeleteMulti(event) {
      if (!this.$refs.DeleteMulti.contains(event.target)) {
        this.isShowMenuExcuteBatch = false;
      }
    },

    /**
     * Mô tả: xử lí sự kiện click ngoài menu feature
     * created by : BNTIEN
     * created date: 03-07-2023 00:03:06
     */
    handleClickOutsideFeature() {
      this.isShowColFeature = false;
    },

    /**
     * Mô tả: Hàm ẩn hiện menu thực hiện hàng loạt
     * created by : BNTIEN
     * created date: 27-06-2023 23:37:04
     */
    onShowExcuteBatch() {
      this.isShowMenuExcuteBatch = !this.isShowMenuExcuteBatch;
    },

    /**
     * Mô tả: Hàm kiểm tra xem checkbox từng hàng đã chọn chưa, nếu rồi thì bỏ chọn và ngược lại
     * created by : BNTIEN
     * created date: 28-06-2023 09:30:13
     */
    checkRow(id) {
      try {
        if (!id) return this.ids;
        if (this.ids.includes(id)) {
          this.ids.splice(this.ids.indexOf(id), 1);
          return this.ids;
        }
        this.ids.push(id);
        return this.ids;
      } catch {
        return;
      }
    },

    /**
     * Mô tả: Xử lí hàm chọn tất cả ở ô checkbox thead
     * created by : BNTIEN
     * created date: 28-06-2023 09:31:07
     */
    checkAllSelect() {
      try {
        if (this.isCheckAll) {
          this.dataTable.Data.map((item) => {
            if (this.ids.includes(item.ProviderId)) {
              this.ids.splice(this.ids.indexOf(item.ProviderId), 1);
            }
          });
        } else {
          if (this.dataTable.Data) {
            this.dataTable.Data.map((item) => {
              if (!this.ids.includes(item.ProviderId)) {
                this.ids.push(item.ProviderId);
              }
            });
          }
        }
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Hiển thị form xác nhận xóa nhiều
     * created by : BNTIEN
     * created date: 28-06-2023 10:34:10
     */
    onShowDialogDeleteMulti() {
      this.isShowDialogConfirmDelete = !this.isShowDialogConfirmDelete;
      this.isOverlay = true;
      this.isDeleteMultipleDialog = true;
    },
    /**
     * Mô tả: Hàm thực hiện xóa nhiều nhà cung cấp theo list id đã chọn
     * created by : BNTIEN
     * created date: 28-06-2023 09:36:08
     */
    async btnConfirmYesDeleteMultipleProvider() {
      try {
        this.isShowLoadding = true;
        const res = await providerService.deleteMutiple(this.ids);
        this.isShowLoadding = false;
        this.isShowDialogConfirmDelete = false;
        this.isOverlay = false;
        if (
          this.$_MISAEnum.CHECK_STATUS.isResponseStatusOk(res.status) &&
          res.data > 0
        ) {
          this.ids = [];
          this.isDeleteMultipleDialog = false;
          this.contentToastSuccess =
            this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.SUCCESS_DELETE;
          this.onShowToastMessage();
          await this.getListProvider();
        }
      } catch {
        return;
      }
    },
    /**
     * Mô tả: Xử lí xuất dữ liệu ra excel
     * created by : BNTIEN
     * created date: 01-07-2023 22:35:32
     */
    async exportData() {
      try {
        const link = this.$refs.ExportListProvider;
        this.isShowLoadding = true;
        await providerService.exportData(link);
        this.isShowLoadding = false;
      } catch {
        return;
      }
    },
  },

  beforeUnmount() {
    // Hủy các sự kiện đã đăng kí
    this.$_MISAEmitter.off("onShowToastMessage");
    this.$_MISAEmitter.off("onShowToastMessageUpdate");
    this.$_MISAEmitter.off("setFormModeAdd");
    this.$_MISAEmitter.off("refreshDataTable");
    this.$_MISAEmitter.off("confirmYesDeleteEntity");
    this.$_MISAEmitter.off("confirmNoDeleteEntity");
    this.$_MISAEmitter.off("confirmYesDeleteMultiple");
    this.$_MISAEmitter.off("closeToastMessage");
    window.removeEventListener("click", this.handleClickOutsidePaging);
    window.removeEventListener("click", this.handleClickOutsideDeleteMulti);
    window.removeEventListener("click", this.handleClickOutsideFeature);
  },
};
</script>

<style>
@import url(./ProviderList.css);

.no-disable {
  border: 1px solid black;
}

.no-disable:hover {
  background-color: #e0e0e0;
  cursor: pointer;
}

input[type="checkbox"] {
  accent-color: #2ca01c;
  width: 16px;
  height: 16px;
  cursor: pointer;
}

input[type="checkbox"]:focus {
  outline: 2px solid var(--color-border-default);
}

.rotate-function-icon {
  transform: rotate(180deg);
}

.active-page {
  border: 1px solid var(--color-border-default);
}

.active-record {
  border: 1px solid var(--color-btn-default);
}

input[type="checkbox"] {
  accent-color: #2ca01c;
  width: 16px;
  height: 16px;
  cursor: pointer;
}

.active-record-item {
  background-color: var(--color-btn-default);
  color: white;
}

.no-disable {
  border: 1px solid black;
}

.no-disable:hover {
  background-color: #e0e0e0;
  cursor: pointer;
}

.checkedRow {
  background-color: #f9ecca;
}

.checkedRow td:first-child,
.checkedRow td:last-child {
  background-color: #f9ecca;
}

.loadding-form-detail {
  left: 50%;
}

.no-data {
  position: fixed;
  top: 50%;
  left: 50%;
}
</style>
