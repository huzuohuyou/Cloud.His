<template>
  <div class="copyright">
   {{copyright}}
  </div>
</template>
<script lang="ts">
import { Component, Vue } from 'vue-property-decorator'
@Component({
  props: {
    copyright: String
  }
})
export default class Footer extends Vue {

}
</script>
<style scoped>
  .copyright{
    padding: 5px;
    margin: 0;
    text-align: center;
    color: rgba(0,0,0,.45);
    font-size: 14px;
  }
</style>


