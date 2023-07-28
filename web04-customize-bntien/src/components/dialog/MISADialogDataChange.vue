<template>
  <div class="overlay-dialog">
    <div
      class="dialog-entity position-display-center"
      id="dialog-question-entity"
    >
      <div class="title-dialog">
        <h1>
          {{ this.$_MISAResource[this.$_LANG_CODE].DIALOG.TITLE.CLOSE_RECORD }}
        </h1>
        <div class="close-icon" @click="btnCancel"></div>
      </div>
      <div class="dialog-content">
        <div class="question-blue-icon dialog-content-icon"></div>
        <div class="dialog-content-main">
          <p>
            {{
              this.$_MISAResource[this.$_LANG_CODE].DIALOG.CONTENT.DATA_CHANGE
            }}
          </p>
        </div>
      </div>
      <div class="dialog-question-footer">
        <div class="dialog-question-footer-left">
          <misa-button-extra
            :textButtonExtra="
              this.$_MISAResource[this.$_LANG_CODE].BUTTON.CANCEL
            "
            class="btn-no-minwwidth"
            @click="btnCancel"
            :tabindex="102"
            @keydown.tab.prevent="resetTab($event.target.value)"
          ></misa-button-extra>
        </div>
        <div class="dialog-question-footer-right">
          <misa-button-extra
            :textButtonExtra="this.$_MISAResource[this.$_LANG_CODE].BUTTON.NO"
            @click="btnNo"
            :tabindex="101"
          ></misa-button-extra>
          <misa-button-default
            :textButtonDefault="
              this.$_MISAResource[this.$_LANG_CODE].BUTTON.YES
            "
            class="btn-no-minwwidth"
            @click="btnYes"
            :tabindex="100"
            ref="SaveRecord"
          ></misa-button-default>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "MISADialogDataChange",
  mounted() {
    this.resetTab();
  },
  methods: {
    resetTab() {
      this.$refs.SaveRecord.$el.focus();
    },
    /**
     * Mô tả: Hàm xử lí sự kiện đồng ý thay đổi dữ liệu
     * created by : BNTIEN
     * created date: 31-05-2023 13:56:30
     */
    btnYes() {
      this.$_MISAEmitter.emit("yesDialogDataChange");
    },

    /**
     * Mô tả: Hàm xử lí sự kiện không đồng ý thay đổi dữ liệu
     * created by : BNTIEN
     * created date: 31-05-2023 13:57:26
     */
    btnNo() {
      this.$_MISAEmitter.emit("noDialogDataChange");
    },

    /**
     * Mô tả: Hàm xử lí sự kiện hủy thay đổi dữ liệu
     * created by : BNTIEN
     * created date: 31-05-2023 13:57:52
     */
    btnCancel() {
      this.$_MISAEmitter.emit("cancelDialogDataChange");
    },
  },
};
</script>

<style>
@import url(@/css/base/dialog.css);
</style>
