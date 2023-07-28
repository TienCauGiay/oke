<template>
  <input
    class="textfield"
    type="text"
    :value="modelValue"
    @input="$emit('update:modelValue', $event.target.value)"
    :title="titleContent"
    ref="inputText"
  />
</template>

<script>
export default {
  name: "MISAInputText",
  props: {
    modelValue: String,
    titleContent: String,
  },
  methods: {
    focus() {
      this.$refs.inputText.focus();
    },
  },
};
</script>

<style scoped>
@import url(@/css/base/input.css);

input {
  height: 32px;
  width: 100%;
}
</style>
