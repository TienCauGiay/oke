<template>
  <button class="btn btn-default">
    <div class="text">{{ this.textButtonDefault }}</div>
  </button>
</template>

<script>
export default {
  name: "MISAButtonDefault",
  props: ["textButtonDefault"],
};
</script>

<style>
@import url(@/css/base/button.css);
</style>
