<template>
  <div class="dialog-entity position-display-center">
    <div class="title-dialog">
      <h1>
        {{ this.$_MISAResource[this.$_LANG_CODE].DIALOG.TITLE.CONFIRM_DELETE }}
      </h1>
      <div class="close-icon" @click="btnNoConfirmDelete"></div>
    </div>
    <div class="dialog-content">
      <div class="warning-yellow-icon dialog-content-icon"></div>
      <div class="dialog-content-main">
        <p v-if="!this.isDeleteMultiple">
          {{ this.contentDelete }}
        </p>
        <p v-else>
          {{ this.contentDeleteMultiple }}
        </p>
      </div>
    </div>
    <div class="dialog-warning-delete-footer">
      <misa-button-extra
        @click="btnNoConfirmDelete"
        :textButtonExtra="this.$_MISAResource[this.$_LANG_CODE].BUTTON.NO"
        :tabindex="400"
        ref="NoConfirmDelete"
      ></misa-button-extra>
      <misa-button-default
        @click="handleDelete"
        :textButtonDefault="this.$_MISAResource[this.$_LANG_CODE].BUTTON.YES"
        :tabindex="401"
        @keydown.tab.prevent="resetTab($event.target.value)"
      ></misa-button-default>
    </div>
  </div>
</template>

<script>
export default {
  name: "MISADialogConfirmDelete",
  props: ["isDeleteMultiple", "contentDelete", "contentDeleteMultiple"],
  mounted() {
    this.resetTab();
  },
  methods: {
    resetTab() {
      this.$refs.NoConfirmDelete.$el.focus();
    },
    /**
     * Mô tả: xử lí chọn hàm xóa nhiều hay xóa ít
     * created by : BNTIEN
     * created date: 28-06-2023 11:22:21
     */
    handleDelete() {
      if (this.isDeleteMultiple) {
        this.btnConfirmDeleteMultiple();
      } else {
        this.btnConfirmDelete();
      }
    },
    /**
     * Mô tả: Hàm gọi sự kiện xóa thực thể khi người dùng chọn có
     * created by : BNTIEN
     * created date: 29-05-2023 08:33:41
     */
    btnConfirmDelete() {
      this.$_MISAEmitter.emit("confirmYesDeleteEntity");
    },

    /**
     * Mô tả: Hàm gọi sự kiện xóa nhiều nhân viên
     * created by : BNTIEN
     * created date: 28-06-2023 11:23:05
     */
    btnConfirmDeleteMultiple() {
      this.$_MISAEmitter.emit("confirmYesDeleteMultiple");
    },

    /**
     * Mô tả: Hàm gọi sự kiện hủy xóa thực thể khi người dùng chọn không
     * created by : BNTIEN
     * created date: 29-05-2023 08:35:00
     */
    btnNoConfirmDelete() {
      this.$_MISAEmitter.emit("confirmNoDeleteEntity");
    },
  },
};
</script>

<style>
@import url(@/css/base/dialog.css);

p {
  line-height: 1.5;
}
</style>
