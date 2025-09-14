<script setup lang="ts">
import { getAppIndexPageService } from '~/utils/pages/index/app-index-page.service';

const _this = (function(i18n, service) {
  const { t: translate } = i18n;

  return {
    translate,
    service
  }
})(
  useI18n(),
  getAppIndexPageService()
)

watchEffect(() => {
  _this.service.loadPageData(_this.translate);
})
</script>

<template>
  <div>
    <section>
      <h2>Index1</h2>
    </section>
    <section>
      <h2>Index2</h2>
    </section>
  </div>
</template>
