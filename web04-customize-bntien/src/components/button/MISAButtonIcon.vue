<template>
  <button
    @click="isShowImportExcel = !isShowImportExcel"
    :class="{ bcg: isShowImportExcel }"
  >
    <div class="dropdown-white-icon">
      <div class="import-excel" v-if="isShowImportExcel">
        {{ this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT.IMPORT_EXCEL }}
      </div>
    </div>
  </button>
</template>

<script>
export default {
  name: "MISAButtonIcon",

  data() {
    return {
      // Khai báo biến quy định trạng thái hiển thị nhập excel
      isShowImportExcel: false,
    };
  },
};
</script>

<style scoped>
@import url(./MISAButtonIcon.css);

.bcg {
  outline: 2px solid var(--color-border-default);
}
</style>
