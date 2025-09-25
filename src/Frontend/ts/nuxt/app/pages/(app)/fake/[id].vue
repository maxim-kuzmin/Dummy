<script setup lang="ts">
  import { useAppFakePage } from '~/utils/domain/app/pages/fake/app-fake-page.composable'
  import { useAppFakePageStore } from '~/utils/domain/app/pages/fake/store/app-fake-page-store.composable'

  definePageMeta({
    middleware: ['app-fake-page-middleware'],
  })

  const { click } = useAppFakePage()
  const { pageKey, clickCount } = useAppFakePageStore()
</script>

<template>
  <div>
    {{ pageKey }}
    <br>
    [<button @click="click">Clicked {{ clickCount }} times</button>]
  </div>
</template>
