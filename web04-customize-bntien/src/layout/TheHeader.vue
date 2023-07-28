<template>
  <div class="content-header">
    <div class="header-title">
      <div id="gn" class="three-dashes-icon icon-tb"></div>
      <p
        :title="
          this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
            .NAME_COMPANY_SELECTED
        "
      >
        {{
          this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
            .NAME_COMPANY_SELECTED
        }}
      </p>
      <div class="dropdown-grey-icon icon-tb"></div>
    </div>
    <div class="header-action">
      <div class="database header-center">
        <div class="database-circle"></div>
        <div title="ngoc_tien_2023_01_01" class="database-text">
          ngoc_tien_2023_01_01
        </div>
      </div>
      <div
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.DOWNLOAD"
        class="download-icon icon-l header-center"
      ></div>
      <div class="search-entity header-center">
        <input
          type="search"
          :placeholder="
            this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
              .PLACEHOLDER_SEARCH_HEADER
          "
        />
        <div class="search-icon icon-tb"></div>
      </div>
      <div
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.SETTING"
        class="setting-icon icon-l"
        style="scale: 1.2 1.2"
      ></div>
      <div
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.MESSENGER"
        class="messenger-icon icon-l"
      ></div>
      <div
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.HELP"
        class="question-icon icon-tb"
      ></div>
      <div
        :title="this.$_MISAResource[this.$_LANG_CODE].TOOLTIP.ALERT"
        class="toast-notification-icon icon-l"
      ></div>
      <div class="info-user">
        <div class="avatar-icon icon-l"></div>
        <p>
          {{
            this.$_MISAResource[this.$_LANG_CODE].TEXT_CONTENT
              .NAME_ACCOUNT_LOGIN
          }}
        </p>
        <div class="dropdown-grey-icon icon-tb"></div>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "TheHeader",
};
</script>

<style>
@import url(@/css/headercontent.css);
</style>
