<template>
  <div class="toast-success">
    <div class="toast-info">
      <div class="check-green-icon"></div>
      <p>
        <b>{{ this.$_MISAResource[this.$_LANG_CODE].TOAST.SUCCESS }} </b>
        {{ this.contentToast }}
      </p>
    </div>
    <div class="toast-exits">
      <div class="icon-tb close-icon" @click="onCloseToastMessage"></div>
      <a href="#">{{ this.$_MISAResource[this.$_LANG_CODE].TOAST.UNDO }}</a>
    </div>
  </div>
</template>

<script>
export default {
  name: "MISAToastSuccess",
  props: ["contentToast"],
  methods: {
    onCloseToastMessage() {
      this.$_MISAEmitter.emit("closeToastMessage");
    },
  },
};
</script>

<style>
@import url(@/css/base/toastmessage.css);
</style>
